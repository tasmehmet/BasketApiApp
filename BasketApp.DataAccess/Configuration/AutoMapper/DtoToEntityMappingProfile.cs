using AutoMapper;
using BasketApp.Dto;
using BasketApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasketApp.DataAccess.Configuration.AutoMapper
{
    public class DtoToEntityMappingProfile : Profile
    {
        public DtoToEntityMappingProfile()
        {
            CreateMap<Basket, BasketDto>().ReverseMap();
            CreateMap<ProductStock, ProductStockDto>().ReverseMap();
        }
    }
}
