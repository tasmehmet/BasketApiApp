using BasketApp.Data.Context;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasketApp.IoC.Bootstrappers
{
    public static class NativeInjectorBootstrapper
    {
        public static void RegisterNativeServices(IServiceCollection services)
        {
            //services.AddDbContext<ApplicationDbContext>();

            //services.AddScoped<ApplicationDbContext>();

        }
    }
}
