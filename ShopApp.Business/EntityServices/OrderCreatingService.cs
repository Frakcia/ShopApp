using Microsoft.EntityFrameworkCore;
using ShopApp.Business.Mapping;
using ShopApp.Contracts.DTO.Order;
using ShopApp.Domain.Entities;
using ShopApp.Infrastructure;

namespace ShopApp.Business.EntityServices
{
  public interface IOrderCreatingService { Task Create(OrderCreateDTO orderCreateDTO); }
  public class OrderCreatingService : IOrderCreatingService
  {
    private readonly DbAppContext _appContext;
    private readonly IUserService _userService;
    private readonly IOrderService _orderService;
    private readonly IDeliveryAdressService _deliveryAdressService;
    public async Task Create(OrderCreateDTO orderCreateDTO)
    {
      //Если заказ анонимен, выяснить если в базе пользователь уже есть или создать его
      if (orderCreateDTO.IsUserAnonymous)
        orderCreateDTO.UserId = await _userService.GetUserIdWithAddAsync(orderCreateDTO.Phone);

      //Если адресс доставки нет у в базе то его надо добавить
      if (orderCreateDTO.IsRequiredDelivery)
        orderCreateDTO.DeliveryAdress.Id = await _deliveryAdressService.GetAdressIdWithAddAsync(orderCreateDTO.DeliveryAdress.AdressName);

      //Что если пока все это делаем заказ который мы хотели забрать руками из магаза, уже приобрели в параллельной транзакции

      //Теперь когда все сделано создаем заказ
      //Либо обернуть в транзакцию тут, либо можем ваще заебашить чистым sql через dapper

      await _orderService.CreateAsync(orderCreateDTO);
      _appContext.SaveChanges();
    }
  }




  public class UserService : IUserService
  {
    private readonly DbAppContext _appContext;

    public async Task<Guid> GetUserIdWithAddAsync(string phone)
    {
      var user = await _appContext.Users
        .Where(e => e.Phone == phone)
        .FirstOrDefaultAsync();

      if (user is null)
      {
        user = new User();
        await _appContext.Users.AddAsync(user);
      }

      return user.Id;
    }
  }
  public class DeliveryAdressService : IDeliveryAdressService
  {
    private readonly DbAppContext _appContext;
    public async Task<Guid> GetAdressIdWithAddAsync(string adressName)
    {
      var deliveryAdress = await _appContext.DeliveryAdresses
        .Where(e => e.Name == adressName)
        .FirstOrDefaultAsync();

      if (deliveryAdress is null)
      {
        deliveryAdress = new DeliveryAdress();
        _appContext.DeliveryAdresses.Add(deliveryAdress);
      }

      return deliveryAdress.Id;
    }
  }
  public class OrderService : IOrderService
  {
    private readonly DbAppContext _appContext;

    public async Task CreateAsync(OrderCreateDTO orderCreateDTO)
    {
      var order = OrderMapper.MapTo(orderCreateDTO);

      order.State = Domain.Enums.OrderState.AwaitingConfirmation;
      order.CreatedUTC = DateTime.UtcNow;

      var productIds = orderCreateDTO.Products.Select(e => e.Id).ToArray();
      var products = _appContext.Products.Where(e => productIds.Contains(e.Id));

      int minRemainQuantity = 0;
      int maxRequiredQuantity = 0;
      var shopPoints = _appContext.ProductShopPoints
          .Where(e => e.ShopPointId == orderCreateDTO.ShopPointDto.Id
          && productIds.Contains(e.ProductId));

      if (!orderCreateDTO.IsRequiredDelivery && orderCreateDTO.ShopPointDto.IsHasAvailiableProducts)
      {
        minRemainQuantity = shopPoints.Min(e => e.Quantity);
        maxRequiredQuantity = orderCreateDTO.Products.Max(e => e.Quantity);

        if (maxRequiredQuantity > minRemainQuantity)
        {
          throw new Exception("Throw Some Custom Exception");
        }
      }

      //Либо обернуть в транзакцию тут, либо можем ваще заебашить чистым sql через dapper
      await _appContext.Orders.AddAsync(order);
      order.Products.AddRange(products);

      foreach (var product in orderCreateDTO.Products)
      {
        var shopPoint = shopPoints.FirstOrDefault(e => e.ProductId == product.Id);
        shopPoint.Quantity -= product.Quantity;
      }
    }
  }
  public interface IUserService { Task<Guid> GetUserIdWithAddAsync(string phone); }
  public interface IDeliveryAdressService { Task<Guid> GetAdressIdWithAddAsync(string adressName);  }
  public interface IOrderService { Task CreateAsync(OrderCreateDTO orderCreateDTO);  }
}
