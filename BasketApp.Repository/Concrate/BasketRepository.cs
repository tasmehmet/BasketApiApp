using BasketApp.Data.Context;
using BasketApp.Entity;
using BasketApp.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasketApp.Repository.Concrate
{
    public class BasketRepository : Repository<Basket>, IBasketRepository
    {
        public BasketRepository(ApplicationDbContext context): base(context)
        {
        }
    }
}
