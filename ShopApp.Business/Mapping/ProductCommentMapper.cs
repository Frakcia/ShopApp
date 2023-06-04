using ShopApp.Contracts.DTO.ProductComment;
using ShopApp.Domain.Entities;

namespace ShopApp.Business.Mapping
{
  public static class ProductCommentMapper
  {
    public static ProductCommentShowDTO MapTo(ProductComment productComment)
    {
      return new ProductCommentShowDTO(productComment.Id, productComment.Text, productComment?.User.Name, productComment.CreatedUTC);
    }
  }
}
