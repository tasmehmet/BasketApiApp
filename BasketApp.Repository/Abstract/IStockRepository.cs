using BasketApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasketApp.Repository.Abstract
{
    public interface IStockRepository : IRepository<ProductStock>
    {
        void DecreaseProductStock(int id, int count);
        void IncreaseProductStock(int id, int count);
    }
}
