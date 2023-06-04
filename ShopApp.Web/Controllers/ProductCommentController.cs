using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopApp.Contracts.DTO.ProductComment;
using ShopApp.Contracts.EntityServices;

namespace ShopApp.Web.Controllers
{
  [Route("[controller]")]
  [ApiController]
  public class ProductCommentController : ControllerBase
  {
    private readonly IProductCommentService _productCommentService;

    public ProductCommentController(IProductCommentService productCommentService)
    {
      _productCommentService = productCommentService;
    }

    [HttpGet("[action]")]
    public async Task<IActionResult> GetByProduct(Guid productId)
    {
      return Ok();
      return Ok(await _productCommentService.GetCommentsByProduct(productId));
    }
  }
}
