using ShopApp.Contracts.DTO.ProductComment;

namespace ShopApp.Contracts.EntityServices
{
  public interface IProductCommentService
  {
    Task<IEnumerable<ProductCommentShowDTO>> GetCommentsByProduct(Guid productId);
  }
}
