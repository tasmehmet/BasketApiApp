using BasketApp.Business.Abstract;
using BasketApp.DataAccess.Abstract;
using BasketApp.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasketApp.Business.Concrate
{
    public class ProductStockManager : IProductStockService
    {
        private readonly IProductStockDal _productStockDal;
        public ProductStockManager(IProductStockDal productStockDal)
        {
            _productStockDal = productStockDal;
        }
        public bool AddAsync(ProductStockDto model)
        {
            return _productStockDal.AddAsync(model);
        }

        public bool DecreaseProductStock(int id, int count)
        {
            return _productStockDal.DecreaseProductStock(id,count);
        }

        public async Task<IEnumerable<ProductStockDto>> GetAllAsync()
        {
            return await _productStockDal.GetAllAsync();
        }

        public ProductStockDto GetById(string id)
        {
            return _productStockDal.GetById(id);
        }

        public async Task<ProductStockDto> GetByIdAsync(string id)
        {
            return await _productStockDal.GetByIdAsync(id);
        }

        public bool HaveStockControl(int id)
        {
            var product = _productStockDal.GetAllAsync()?.Result?.FirstOrDefault(x => x.ProductId == id);
            var result = product.StockCount > 0 ? true : false;
            return result;
        }

        public bool IncreaseProductStock(int id, int count)
        {
            return _productStockDal.IncreaseProductStock(id,count);
        }

        public bool Remove(string id)
        {
            return _productStockDal.Remove(id);
        }

        public bool Update(ProductStockDto model)
        {
            return _productStockDal.Update(model);
        }
    }
}
