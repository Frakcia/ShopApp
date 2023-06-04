using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.Domain.Entities
{
  public class ShoppingCart
  {
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public List<Product> Products { get; set; }
  }
}
