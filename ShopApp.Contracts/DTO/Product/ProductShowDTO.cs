namespace ShopApp.Contracts.DTO.Product
{
  public class ProductShowDTO
  {
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string ManufacturerName { get; set; }
    public bool AreAvailable { get; set; }
  }
}
