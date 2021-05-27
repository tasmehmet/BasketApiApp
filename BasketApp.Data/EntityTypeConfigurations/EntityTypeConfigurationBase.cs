using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasketApp.Data.EntityTypeConfigurations
{
    public abstract class EntityTypeConfigurationBase<T> : IEntityTypeConfiguration<T>
        where T : class
    {
        public abstract void Configure(EntityTypeBuilder<T> builder);
    }
}
