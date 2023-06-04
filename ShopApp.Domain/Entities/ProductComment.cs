using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.Domain.Entities
{
  public class ProductComment
  {
    public Guid Id { get; set; } 
    public string Text { get; set; }
    public Guid ProductId { get; set; }
    public Guid UserId { get; set; }
    public User User { get; set; } 
    public DateTime CreatedUTC { get; set; }
  }
}
