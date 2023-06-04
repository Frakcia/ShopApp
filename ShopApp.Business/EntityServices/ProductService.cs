using Microsoft.EntityFrameworkCore;
using ShopApp.Business.Mapping;
using ShopApp.Contracts.DTO.Product;
using ShopApp.Contracts.EntityServices;
using ShopApp.Contracts.Models;
using ShopApp.Infrastructure;

namespace ShopApp.Business.EntityServices
{
  public class ProductService : IProductService
  {
    private readonly DbAppContext _appContext;
    public async Task<IEnumerable<ProductShowDTO>> GetProductsByFilterAsync(ProductsFilterModel productsFilterModel)
    {
      var products = await _appContext.Products
        .Include(e=> e.Manufacturer)
        .Where(p=> p.ProductCategory == productsFilterModel.ProductCategory)
        .Skip(productsFilterModel.SkipCount)
        .Take(productsFilterModel.PageSize)
        .Select(p=> ProductMapper.MapTo(p))
        .ToArrayAsync();

      return products;
    }
  }
}
