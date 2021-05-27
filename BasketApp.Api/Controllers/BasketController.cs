using BasketApp.Business.Abstract;
using BasketApp.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasketApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IBasketService _basketService;
        private readonly IProductStockService _productStockService;

        public BasketController(IBasketService basketService, IProductStockService productStockService)
        {
            _basketService = basketService;
            _productStockService = productStockService;
        }

        [HttpGet]
        public IActionResult GetBasketAll()
        {
            var data = _basketService.GetAll().ToList();
            return Ok(data);
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetBasketById(string Id)
        {
            if (string.IsNullOrEmpty(Id))
            {
                return BadRequest();
            }

            var data = await _basketService.GetByIdAsync(Id);
            return Ok(data);
        }

        [HttpPost]
        public IActionResult AddProduct([FromBody] BasketDto model)
        {
            var haveStock = _productStockService.HaveStockControl(model.ProductId);
            if (!haveStock)
            {
                return BadRequest();
            }

            var stockResult = _productStockService.DecreaseProductStock(model.ProductId, model.ProductCount);
            bool result = false;

            if (stockResult)
            {
                result = _basketService.Add(model);
            }
            
            return result && stockResult ? Ok() : BadRequest();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProduct(string id)
        {
            var result = _basketService.Remove(id);
            var basket = await _basketService.GetByIdAsync(id);
            var stockResult = _productStockService.IncreaseProductStock(basket.ProductId,basket.ProductCount);
            return result && stockResult ? Ok() : BadRequest();
        }
    }
}
