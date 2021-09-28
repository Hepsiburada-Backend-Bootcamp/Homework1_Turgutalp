using Homework1.Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Homework1.Data.Seeds
{
    public class ProductSeed : IEntityTypeConfiguration<Product>
    {
        private readonly int[] _ids;


        public ProductSeed(int[] ids)
        {
            _ids = ids;
        }

        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(
                new Product
                {
                    Id = 1,
                    ProductName = "XboxSeriesX",
                    ProductPrice = 8.000m,
                    ProductStock = 500,
                    CategoryId = _ids[0]
                },
                new Product
                {
                    Id = 2,
                    ProductName = "XboxSeriesS",
                    ProductPrice = 6.000m,
                    ProductStock = 500,
                    CategoryId = _ids[0]
                },
                new Product
                {
                    Id = 3,
                    ProductName = "Playstation5",
                    ProductPrice = 9.000m,
                    ProductStock = 900,
                    CategoryId = _ids[0]
                },
                new Product
                {
                    Id = 4,
                    ProductName = "Dell Alienware",
                    ProductPrice = 8.000m,
                    ProductStock = 500,
                    CategoryId = _ids[1]
                },
                new Product
                {
                    Id = 5,
                    ProductName = "Tulpar T7",
                    ProductPrice = 22.000m,
                    ProductStock = 200,
                    CategoryId = _ids[1]
                },
                new Product
                {
                    Id = 6,
                    ProductName = "Zephyrus g14",
                    ProductPrice = 30.000m,
                    ProductStock = 100,
                    CategoryId = _ids[1]
                }
            );
        }
    }
}