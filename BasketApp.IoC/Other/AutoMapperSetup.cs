using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasketApp.IoC.Other
{
    public static class AutoMapperSetup
    {
        public static void RegisterMappings(IServiceCollection services)
        {
            DataAccess.Configuration.AutoMapper.AutoMapperSetup.AddAutoMapperSetup(services);
        }
    }
}
