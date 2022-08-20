using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductApi.Models;

namespace ProductApi.Context.ConfigurationEntity
{
    public class ProductConfigureExtensionType : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("product");

            builder.HasKey(x => x.Id);

            builder
                .Property(x => x.Id)
                .UseMySqlIdentityColumn()
                .HasColumnName("id");

            builder
                .Property(x => x.Name)
                .HasColumnName("name")
                .HasMaxLength(256)
                .IsRequired();

            builder
                .Property<string>(x => x.Description)
                .HasColumnName("description")
                .HasMaxLength(500);

            builder
                .Property(x => x.CategoryName)
                .HasColumnName("category_name")
                .HasMaxLength(50);

            builder
                .Property(x => x.ImageURL)
                .HasColumnName("imagem_url")
                .HasMaxLength(300);

            builder
                .Property<decimal>(x => x.Price)
                .HasColumnType("decimal(10, 4)")
                .IsRequired();
        }
    }
}
