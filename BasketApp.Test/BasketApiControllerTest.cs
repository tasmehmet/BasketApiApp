using BasketApp.Api.Controllers;
using BasketApp.Business.Abstract;
using BasketApp.Dto;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BasketApp.Test
{
    public class BasketApiControllerTest
    {
        private readonly Mock<IBasketService> _mockBasketService;
        private readonly Mock<IProductStockService> _mockProductStockService;
        private readonly BasketController _basketController;

        private List<BasketDto> basketDtos;
        private BasketDto basketDto;
        private List<ProductStockDto> productStockDtos;

        public BasketApiControllerTest()
        {
            _mockBasketService = new Mock<IBasketService>();
            _mockProductStockService = new Mock<IProductStockService>();
            _basketController = new BasketController(_mockBasketService.Object, _mockProductStockService.Object);
            basketDtos = new List<BasketDto>
            {
                new BasketDto()
                {
                    Id = "8b97bed5-be61-4e76-9956-ae5b988efa12",
                    Name = "Kalem",
                    Category = "Kırtasiye",
                    Description = "Kalemler",
                    ImageUrl="image.jpg",
                    UserID = 1,
                    Price= 10,
                    ProductId = 1,
                    ProductCount = 1,
                    CreatedDateUtc= DateTime.Now,
                    UpdatedDateUtc= DateTime.Now,
                }
            };

            basketDto = new BasketDto()
            {
                Id = "8b97bed5-be61-4e76-9956-ae5b988efa12",
                Name = "Kalem",
                Category = "Kırtasiye",
                Description = "Kalemler",
                ImageUrl = "image.jpg",
                UserID = 1,
                Price = 10,
                ProductId = 1,
                ProductCount = 1,
                CreatedDateUtc = DateTime.Now,
                UpdatedDateUtc = DateTime.Now,
            };

            productStockDtos = new List<ProductStockDto>
            {
                new ProductStockDto()
                {
                    ProductId = 1,
                    StockCount = 100,
                    Id = "1",
                    CreatedDateUtc = DateTime.Now,
                    UpdatedDateUtc = DateTime.Now
                }
            };
        }

        [Fact]
        public void GetBasketAll_ActionExecutes_ReturnOkWithBaskets()
        {
            _mockBasketService.Setup(x => x.GetAll()).Returns(basketDtos);

            var result = _basketController.GetBasketAll();

            var okResult = Assert.IsType<OkObjectResult>(result);

            var returnBaskets = Assert.IsAssignableFrom<IEnumerable<BasketDto>>(okResult.Value);

            Assert.Single(returnBaskets.ToList());
        }


        [Fact]
        public void GetBasketById_IdInValid_ReturnBadRequest()
        {
            BasketDto basket = null;

            _mockBasketService.Setup(x => x.GetByIdAsync(string.Empty)).ReturnsAsync(basket);

            var result = _basketController.GetBasketById(string.Empty);

            Assert.IsType<BadRequestResult>(result.Result);

        }

        [Fact]
        public void AddProduct_ActionExecutes_ReturnOkRequest()
        {
            _mockBasketService.Setup(x => x.Add(basketDto)).Returns(true);

            _mockProductStockService.Setup(x => x.HaveStockControl(1)).Returns(true);

            _mockProductStockService.Setup(x => x.DecreaseProductStock(1,1)).Returns(true);

            var result = _basketController.AddProduct(basketDto);

            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public void GetBasketById_ActionExecutes_ReturnBasket()
        {
            _mockBasketService.Setup(x => x.GetByIdAsync("8b97bed5-be61-4e76-9956-ae5b988efa12")).ReturnsAsync(basketDtos?.FirstOrDefault());

            var result = _basketController.GetBasketById("8b97bed5-be61-4e76-9956-ae5b988efa12");

            var okResult = Assert.IsType<OkObjectResult>(result.Result);

            var returnBaskets = Assert.IsAssignableFrom<BasketDto>(okResult.Value);

            Assert.Equal(basketDtos?.FirstOrDefault(), returnBaskets);
        }
    }
}
