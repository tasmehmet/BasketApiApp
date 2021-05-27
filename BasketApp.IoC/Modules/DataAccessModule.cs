using Autofac;
using AutoMapper;
using BasketApp.DataAccess.Abstract;
using BasketApp.DataAccess.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasketApp.IoC.Modules
{
    public class DataAccessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<BasketDal>().As<IBasketDal>();
            builder.RegisterType<ProductStockDal>().As<IProductStockDal>();
            builder.RegisterType<Mapper>().As<IMapper>();
        }
    }
}
