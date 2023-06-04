using Microsoft.EntityFrameworkCore;
using ShopApp.Business.Mapping;
using ShopApp.Contracts.DTO.ProductComment;
using ShopApp.Contracts.EntityServices;
using ShopApp.Infrastructure;

namespace ShopApp.Business.EntityServices
{
  public class ProductCommentService : IProductCommentService
  {
    private readonly DbAppContext _appContext;
    public ProductCommentService(DbAppContext appContext)
    {
      _appContext = appContext;
    }

    public async Task<IEnumerable<ProductCommentShowDTO>> GetCommentsByProduct(Guid productId)
    {
      var comments = await _appContext.ProductComments
        .Where(e => e.ProductId == productId)
        .Select(e => ProductCommentMapper.MapTo(e))
        .ToArrayAsync();

      return comments;
    }
  }
}
