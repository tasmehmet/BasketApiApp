using Autofac;
using BasketApp.IoC.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasketApp.IoC.Bootstrappers
{
    public class AutofacBootstrapper
    {
        public static void RegisterModules(ContainerBuilder builder)
        {
            builder.RegisterModule(new DataModule());
            builder.RegisterModule(new DataAccessModule());
            builder.RegisterModule(new BusinessModule());
        }
    }
}
