using BasketApp.Data.Context;
using BasketApp.Entity;
using BasketApp.Repository.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasketApp.Repository.Concrate
{
    public class StockRepository : Repository<ProductStock>, IStockRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly DbSet<ProductStock> _dbSet;
        public StockRepository(ApplicationDbContext context): base(context)
        {
            _db = context;
            _dbSet = _db.Set<ProductStock>();
        }

        public void DecreaseProductStock(int id, int count)
        {
            var product = _dbSet?.FirstOrDefault(x => x.ProductId == id);
            product.StockCount -= count;
            _dbSet.Update(product);
        }
        public void IncreaseProductStock(int id, int count)
        {
            var product = _dbSet?.FirstOrDefault(x => x.ProductId == id);
            product.StockCount += count;
            _dbSet.Update(product);
        }
    }
}
