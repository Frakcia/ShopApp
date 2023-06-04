using ShopApp.Contracts.DTO.Product;
using ShopApp.Domain.Entities;

namespace ShopApp.Business.Mapping
{
  public static class ProductMapper
  {
    public static ProductShowDTO MapTo(Product product)
    {
      return new ProductShowDTO
      {
        Id= product.Id,
        Name= product.Name,
        Description= product.Description,
        ManufacturerName = product.Manufacturer.Name,
        AreAvailable = true
      };
    }
  }
}
