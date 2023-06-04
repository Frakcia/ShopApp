namespace ShopApp.Contracts.DTO.Order
{
  public class OrderCreateDTO
  {
    public Guid? UserId { get; set; }
    public bool IsUserAnonymous { get; set; }
    public string Phone { get; set; }
    public List<ProductOrderDTO> Products { get; set; }
    public bool IsRequiredDelivery { get; set; }
    public Guid RegionPointId { get; set; }
    public DeliveryAdressDTO? DeliveryAdress { get; set; }
    public ShopPointDTO? ShopPointDto { get; set; }
  }

  public class ProductOrderDTO
  {
    public Guid Id { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }
  }

  //public class RegionPointDTO
  //{
  //  public Guid Id { get; set; }
  //}

  public class ShopPointDTO
  {
    public Guid Id { get; set; }
    public bool IsHasAvailiableProducts { get; set; }
  }

  public class DeliveryAdressDTO
  {
    public Guid Id { get; set; }
    public string AdressName { get; set; }
  }
}
