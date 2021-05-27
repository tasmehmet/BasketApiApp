using Autofac;
using BasketApp.Business.Abstract;
using BasketApp.Business.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasketApp.IoC.Modules
{
    public class BusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<BasketManager>().As<IBasketService>();
            builder.RegisterType<ProductStockManager>().As<IProductStockService>();
        }
    }
}
