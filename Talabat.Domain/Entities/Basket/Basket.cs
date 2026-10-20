using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talabat.Domain.Entities.Basket
{
    public class Basket : BaseEntity<string>
    {
        public IEnumerable<BasketItem> Items { get; set; }
    }
}
