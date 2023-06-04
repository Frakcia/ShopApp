namespace ShopApp.Domain.Entities
{
  public class ProductShopPoint
  {
    public Guid Id { get; set; }
    public Guid ProductId { get; set; }
    public Product Product { get; set; }
    public Guid ShopPointId { get; set; }
    public ShopPoint ShopPoint { get; set; }
    public int Quantity { get; set; }
  }
}
