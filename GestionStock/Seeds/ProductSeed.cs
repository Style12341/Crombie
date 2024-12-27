using GestionStock.Models.Entitiy;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestionStock.Seeds
{
    public class ProductSeed : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            var electronicsId = 1;
            var clothingId = 2;
            var foodId = 3;
            var booksId = 4;
            var furnitureId = 5;
            var toysId = 6;

            builder.HasData(
                new Product
                {
                    Id = 1,
                    Name = "Laptop",
                    Code = "LPTP001",
                    Description = "A laptop computer.",
                    CategoryId = electronicsId,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new Product
                {
                    Id = 2,
                    Name = "Smartphone",
                    Code = "SMPH001",
                    Description = "A smartphone device.",
                    CategoryId = electronicsId,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new Product
                {
                    Id = 3,
                    Name = "T-Shirt",
                    Code = "TSHRT001",
                    Description = "A cotton t-shirt.",
                    CategoryId = clothingId,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new Product
                {
                    Id = 4,
                    Name = "Jeans",
                    Code = "JNS001",
                    Description = "A pair of denim jeans.",
                    CategoryId = clothingId,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new Product
                {
                    Id = 5,
                    Name = "Apple",
                    Code = "FRT001",
                    Description = "A fresh apple.",
                    CategoryId = foodId,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new Product
                {
                    Id = 6,
                    Name = "Bread",
                    Code = "BRD001",
                    Description = "A loaf of bread.",
                    CategoryId = foodId,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new Product
                {
                    Id = 7,
                    Name = "Novel",
                    Code = "BKS001",
                    Description = "A fiction novel.",
                    CategoryId = booksId,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new Product
                {
                    Id = 8,
                    Name = "Desk",
                    Code = "FRN001",
                    Description = "A wooden desk.",
                    CategoryId = furnitureId,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new Product
                {
                    Id = 9,
                    Name = "Chair",
                    Code = "FRN002",
                    Description = "A comfortable chair.",
                    CategoryId = furnitureId,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new Product
                {
                    Id = 10,
                    Name = "Toy Car",
                    Code = "TOY001",
                    Description = "A small toy car.",
                    CategoryId = toysId,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                }
            );
        }
    }
}
