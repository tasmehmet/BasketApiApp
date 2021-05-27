using BasketApp.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasketApp.DataAccess.Abstract
{
    public interface IProductStockDal
    {
        bool AddAsync(ProductStockDto model);
        Task<ProductStockDto> GetByIdAsync(string id);
        ProductStockDto GetById(string id);
        Task<IEnumerable<ProductStockDto>> GetAllAsync();
        bool Update(ProductStockDto model);
        bool Remove(string id);
        bool DecreaseProductStock(int id, int count);
        bool IncreaseProductStock(int id, int count);
    }
}
