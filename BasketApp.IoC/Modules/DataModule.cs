using Autofac;
using BasketApp.Data.Context;
using BasketApp.Repository.Abstract;
using BasketApp.Repository.Concrate;

namespace BasketApp.IoC.Modules
{
    public class DataModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType(typeof(ApplicationDbContext)).InstancePerRequest();

            builder.RegisterType<BasketRepository>().As<IBasketRepository>();
            builder.RegisterType<StockRepository>().As<IStockRepository>();
            builder.RegisterType<ApplicationDbContext>();
        }
    }
}
