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
    public class BasketManager : IBasketService
    {
        private readonly IBasketDal _basketDal;
        public BasketManager(IBasketDal basketDal)
        {
            _basketDal = basketDal;
        }

        public bool Add(BasketDto model)
        {
            return _basketDal.Add(model);
        }

        public IEnumerable<BasketDto> GetAll()
        {
            return _basketDal.GetAll();
        }

        public BasketDto GetById(string id)
        {
            return _basketDal.GetById(id);
        }

        public async Task<BasketDto> GetByIdAsync(string id)
        {
            return await _basketDal.GetByIdAsync(id);
        }

        public bool Remove(string id)
        {
            return _basketDal.Remove(id);
        }

        public bool Update(BasketDto model)
        {
            return _basketDal.Update(model);
        }
    }
}
