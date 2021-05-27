using Autofac;
using BasketApp.IoC.Bootstrappers;
using BasketApp.IoC.Other;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace BasketApp.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public ILifetimeScope AutofacContainer { get; private set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();

            RegisterNativeServices(services);

            RegisterAutoMapper(services);


            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "BasketApp.Api", Version = "v1" });
            });
        }
        public void ConfigureContainer(ContainerBuilder builder)
        {
            RegisterAutofacModules(builder);
        }

        private static void RegisterNativeServices(IServiceCollection services)
        {
            NativeInjectorBootstrapper.RegisterNativeServices(services);
        }

        private static void RegisterAutofacModules(ContainerBuilder builder)
        {
            AutofacBootstrapper.RegisterModules(builder);
        }

        private static void RegisterAutoMapper(IServiceCollection services)
        {
            AutoMapperSetup.RegisterMappings(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "BasketApp.Api v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
