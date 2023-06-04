namespace ShopApp.Contracts.DTO.ProductComment
{
  public class ProductCommentShowDTO
  {
    public ProductCommentShowDTO(Guid id, string text, string userName, DateTime createdUTC)
    {
      Id = id;
      Text = text;
      UserName = userName;
      CreatedUTC = createdUTC;
    }
    public Guid Id { get; set; }
    public string Text { get; set; }
    public string UserName { get; set; }
    public DateTime CreatedUTC { get; set; }
  }
}
