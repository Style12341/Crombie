using GestionStock.Models.Entitiy;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestionStock.Seeds
{
    public class SectorSeed : IEntityTypeConfiguration<Sector>
    {
        void IEntityTypeConfiguration<Sector>.Configure(EntityTypeBuilder<Sector> builder)
        {
            builder.HasData(
                new Sector
                {
                    Id = 1,
                    Name = "Electronics",
                    Description = "A sector for electronics.",
                    StoreId = 1,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new Sector
                {
                    Id = 2,
                    Name = "Clothing",
                    Description = "A sector for clothing.",
                    StoreId = 1,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new Sector
                {
                    Id = 3,
                    Name = "Food",
                    Description = "A sector for food.",
                    StoreId = 1,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new Sector
                {
                    Id = 4,
                    Name = "Books",
                    Description = "A sector for books.",
                    StoreId = 1,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new Sector
                {
                    Id = 5,
                    Name = "Furniture",
                    Description = "A sector for furniture.",
                    StoreId = 1,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new Sector
                {
                    Id = 6,
                    Name = "Toys",
                    Description = "A sector for toys.",
                    StoreId = 1,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                }
                );
        }
    }
}
