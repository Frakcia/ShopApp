using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.Domain.Entities
{
  public class RegionPoint
  {
    public Guid Id { get; set; }
    public string Name { get; set; }
    public double PriceMnojitel { get; set; }
    public List<ShopPoint> ShopPoints { get; set; }
  }
}
