using Homework1.Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Homework1.Data.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.ProductName).IsRequired().HasMaxLength(200);
            builder.Property(x => x.ProductStock).IsRequired();
            builder.Property(x => x.ProductPrice).IsRequired().HasColumnType("decimal(18,2");
            builder.Property(x => x.InnerBarcode).HasMaxLength(50);
            builder.ToTable("Products");

        }
    }
}