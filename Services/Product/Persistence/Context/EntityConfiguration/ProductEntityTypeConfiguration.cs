using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Context.EntityConfiguration
{
    public class ProductEntityTypeConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("product");
            ConfigureId(builder);
        }

        private void ConfigureId(EntityTypeBuilder<Product> builder)
        {
            builder
                .Property(x => x.Id)
                .HasColumnName("id")
                .UseMySqlIdentityColumn()
                .IsRequired();
            
            builder
                .HasKey(x => x.Id);
        }
    }
}
