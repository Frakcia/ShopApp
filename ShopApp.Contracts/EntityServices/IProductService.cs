using ShopApp.Contracts.DTO.Product;
using ShopApp.Contracts.Models;

namespace ShopApp.Contracts.EntityServices
{
  public interface IProductService
  {
    Task<IEnumerable<ProductShowDTO>> GetProductsByFilterAsync(ProductsFilterModel productsFilterModel);
  }
}
