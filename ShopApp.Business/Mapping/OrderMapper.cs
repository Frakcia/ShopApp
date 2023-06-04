using ShopApp.Contracts.DTO.Order;
using ShopApp.Domain.Entities;

namespace ShopApp.Business.Mapping
{
  public static class OrderMapper
  {
    public static Order MapTo(OrderCreateDTO orderCreateDTO)
    {
      return new Order()
      {
        UserId = orderCreateDTO.UserId.Value,
        ShopPointId = orderCreateDTO.ShopPointDto?.Id,
        DeliveryAdressId = orderCreateDTO.DeliveryAdress?.Id,
        IsAnonymousCreating = orderCreateDTO.IsUserAnonymous,
        Price = orderCreateDTO.Products.Sum(p => p.Price * p.Quantity)
      };
    }
  }
}
