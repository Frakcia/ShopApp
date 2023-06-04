namespace ShopApp.Domain.Entities
{
  public class ShopPoint
  {
    public Guid Id { get; set; }
    public string Name { get; set; }
    public Guid RegionPointId { get; set; }
  }
}
