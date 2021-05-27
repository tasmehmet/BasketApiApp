using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasketApp.Entity
{
    public class ProductStock : Entity
    {
        public int ProductId { get; set; }
        public int StockCount { get; set; }
    }
}
