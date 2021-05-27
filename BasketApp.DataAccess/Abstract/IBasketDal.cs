using BasketApp.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasketApp.DataAccess.Abstract
{
    public interface IBasketDal
    {
        bool Add(BasketDto model);
        Task<BasketDto> GetByIdAsync(string id);
        BasketDto GetById(string id);
        IEnumerable<BasketDto> GetAll();
        bool Update(BasketDto model);
        bool Remove(string id);
    }
}
