using Microsoft.AspNetCore.Mvc;
using ShopApp.Business.EntityServices;
using ShopApp.Contracts.DTO.Order;

namespace ShopApp.Web.Controllers
{
  [Route("[controller]")]
  [ApiController]
  public class OrderController : ControllerBase
  {
    private readonly IOrderCreatingService _orderService;

    //public OrderController(IOrderService orderService)
    //{
    //  _orderService = orderService;
    //}

    [HttpPost("[action]")]
    public async Task<IActionResult> Create(OrderCreateDTO orderCreateDTO)
    {
      return Ok();
      await _orderService.Create(orderCreateDTO);
      return Ok();
    }
  }
}
