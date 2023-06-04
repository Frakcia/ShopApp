using ShopApp.Domain.Enums;

namespace ShopApp.Domain.Entities
{
  public class Order
  {
    public int Id { get; set; }
    public List<Product> Products { get; set; }
    public Guid UserId { get; set; }
    public User User { get; set; }
    public OrderState State { get; set; }
    public Guid? ShopPointId { get; set; }
    public ShopPoint? ShopPoint { get; set; }
    public Guid? DeliveryAdressId { get; set; }
    public DeliveryAdress? DeliveryAdress { get; set; }
    public bool IsAnonymousCreating { get; set; }
    public decimal Price { get; set; }
    public DateTime CreatedUTC { get; set; }
    public DateTime? LastUpdatedUTC { get; set; }
  }
}
