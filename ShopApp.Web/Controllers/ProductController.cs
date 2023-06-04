using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopApp.Contracts.EntityServices;
using ShopApp.Contracts.Models;

namespace ShopApp.Web.Controllers
{
  [Route("[controller]")]
  [ApiController]
  public class ProductController : ControllerBase
  {
    private readonly IProductService _productService;

    [HttpGet("[action]")]
    public IActionResult GetProductsCategories()
    {
      return Ok();
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> GettList(ProductsFilterModel productsFilterModel)
    {
      return Ok();
      return Ok(await _productService.GetProductsByFilterAsync(productsFilterModel));
    }
  }
}
