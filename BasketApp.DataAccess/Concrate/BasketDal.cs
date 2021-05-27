using AutoMapper;
using BasketApp.DataAccess.Abstract;
using BasketApp.Dto;
using BasketApp.Entity;
using BasketApp.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasketApp.DataAccess.Concrate
{
    public class BasketDal : IBasketDal
    {
        private readonly IBasketRepository _basketRepository;
        private readonly IMapper _mapper;
        public BasketDal(IBasketRepository basketRepository, IMapper mapper)
        {
            _basketRepository = basketRepository;
            _mapper = mapper;
        }

        public bool Add(BasketDto model)
        {
            _basketRepository.Add(_mapper.Map<Basket>(model));
            var result = _basketRepository.SaveChanges();
            return result > 0;
        }

        public IEnumerable<BasketDto> GetAll()
        {
            var data = _basketRepository.GetAll();
            return _mapper.Map<IEnumerable<BasketDto>>(data);
        }

        public BasketDto GetById(string id)
        {
            var data = _basketRepository.GetById(id);
            return _mapper.Map<BasketDto>(data);
        }

        public async Task<BasketDto> GetByIdAsync(string id)
        {
            var data = await _basketRepository.GetByIdAsync(id);
            return _mapper.Map<BasketDto>(data);
        }

        public bool Remove(string id)
        {
            _basketRepository.Remove(id);
            var result = _basketRepository.SaveChanges();
            return result > 0;
        }

        public bool Update(BasketDto model)
        {
            _basketRepository.Update(_mapper.Map<Basket>(model));
            var result = _basketRepository.SaveChanges();
            return result > 0;
        }
    }
}
