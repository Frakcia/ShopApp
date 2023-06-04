using ShopApp.Domain.Enums;

namespace ShopApp.Domain.Entities
{
  public class Product
  {
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Image { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public int RemainCount { get; set; }
    public Guid ProductId { get; set; }
    public int ManufacturerId { get; set; }
    public Manufacturer Manufacturer { get; set; }
    public ProductCategory ProductCategory { get; set; }
    public int Populyarity {  get; set; }
    public List<RegionPoint> RegionPoints { get; set; }
    public List<ProductComment>? ProductComments { get; set; }
  }
}
