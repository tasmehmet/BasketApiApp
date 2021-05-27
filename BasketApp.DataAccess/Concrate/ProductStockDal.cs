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
    public class ProductStockDal : IProductStockDal
    {
        private readonly IStockRepository _stockRepository;
        private readonly IBasketRepository _basketRepository;
        private readonly IMapper _mapper;

        public ProductStockDal(IStockRepository stockRepository, IMapper mapper)
        {
            _stockRepository = stockRepository;
            _mapper = mapper;
        }

        public bool AddAsync(ProductStockDto model)
        {
             _stockRepository.Add(_mapper.Map<ProductStock>(model));
            var result = _stockRepository.SaveChanges();
            return result > 0;
        }

        public bool DecreaseProductStock(int id, int count)
        {
            _stockRepository.DecreaseProductStock(id,count);
            var result = _stockRepository.SaveChanges();
            return result > 0;
        }

        public Task<IEnumerable<ProductStockDto>> GetAllAsync()
        {
            var data = _stockRepository.GetAll();
            return _mapper.Map<Task<IEnumerable<ProductStockDto>>>(data);
        }

        public ProductStockDto GetById(string id)
        {
            var data = _stockRepository.GetById(id);
            return _mapper.Map<ProductStockDto>(data);
        }

        public async Task<ProductStockDto> GetByIdAsync(string id)
        {
            var data = await _stockRepository.GetByIdAsync(id);
            return _mapper.Map<ProductStockDto>(data);
        }

        public bool IncreaseProductStock(int id, int count)
        {
            _stockRepository.IncreaseProductStock(id,count);
            var result = _stockRepository.SaveChanges();
            return result > 0;
        }

        public bool Remove(string id)
        {
            _stockRepository.Remove(id);
            var result = _stockRepository.SaveChanges();
            return result > 0;
        }

        public bool Update(ProductStockDto model)
        {
            _stockRepository.Update(_mapper.Map<ProductStock>(model));
            var result = _stockRepository.SaveChanges();
            return result > 0;
        }
    }
}
