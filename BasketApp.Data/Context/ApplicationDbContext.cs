using BasketApp.Data.EntityTypeConfigurations;
using BasketApp.Entity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasketApp.Data.Context
{
    public class ApplicationDbContext : DbContext
    {
        private readonly IHostingEnvironment _hostEnvironment;

        #region DbSet
        public DbSet<Basket> Baskets { get; set; }
        public DbSet<ProductStock> ProductStocks { get; set; }
        #endregion
        public ApplicationDbContext(IHostingEnvironment hostEnvironment)
        {
            _hostEnvironment = hostEnvironment;
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.ApplyConfigurationsFromAssembly(typeof(EntityTypeConfigurationBase<>).Assembly);
            builder.Model.SetDefaultSchema("dbo");

            base.OnModelCreating(builder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(_hostEnvironment.ContentRootPath)
                .AddJsonFile("appsettings.json")
                .AddJsonFile($"appsettings.{_hostEnvironment.EnvironmentName}.json", true)
                .Build();

            optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));
            base.OnConfiguring(optionsBuilder);
        }

    }
}
