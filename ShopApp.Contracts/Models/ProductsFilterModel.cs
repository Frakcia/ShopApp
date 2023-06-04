using ShopApp.Domain.Enums;

namespace ShopApp.Contracts.Models
{
  public class ProductsFilterModel
  {
    public int SkipCount { get { return (PageNumber - 1) * PageSize; } }
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public ProductCategory ProductCategory { get; set; }
  }
}
