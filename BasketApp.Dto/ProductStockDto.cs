using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasketApp.Dto
{
    public class ProductStockDto
    {
        public string Id { get; set; }
        public int ProductId { get; set; }
        public int StockCount { get; set; }
        public DateTime CreatedDateUtc { get; set; }
        public DateTime UpdatedDateUtc { get; set; }
    }
}
