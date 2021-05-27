using Microsoft.Extensions.DependencyInjection;
using System;

namespace BasketApp.DataAccess.Configuration.AutoMapper
{
    public static class AutoMapperSetup
    {
        public static void AddAutoMapperSetup(IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            AutoMapperConfig.RegisterMappings();
        }
    }
}
