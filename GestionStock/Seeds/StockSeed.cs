using GestionStock.Models.Entitiy;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestionStock.Seeds
{
    public class StockSeed : IEntityTypeConfiguration<StockProductStore>
    {
        void IEntityTypeConfiguration<StockProductStore>.Configure(EntityTypeBuilder<StockProductStore> builder)
        {
            builder.HasData(
                new StockProductStore
                {
                    ProductId = 1,
                    StoreId = 1,
                    SectorId = 1,
                    Quantity = 10,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new StockProductStore
                {
                    ProductId = 2,
                    StoreId = 1,
                    SectorId = 1,
                    Quantity = 10,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new StockProductStore
                {
                    ProductId = 3,
                    StoreId = 1,
                    SectorId = 2,
                    Quantity = 10,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new StockProductStore
                {
                    ProductId = 4,
                    StoreId = 1,
                    SectorId = 2,
                    Quantity = 10,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new StockProductStore
                {
                    ProductId = 5,
                    StoreId = 1,
                    SectorId = 3,
                    Quantity = 10,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new StockProductStore
                {
                    ProductId = 6,
                    StoreId = 1,
                    SectorId = 3,
                    Quantity = 10,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new StockProductStore
                {
                    ProductId = 7,
                    StoreId = 1,
                    SectorId = 4,
                    Quantity = 10,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new StockProductStore
                {
                    ProductId = 8,
                    StoreId = 1,
                    SectorId = 5,
                    Quantity = 10,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new StockProductStore
                {
                    ProductId = 9,
                    StoreId = 1,
                    SectorId = 5,
                    Quantity = 10,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new StockProductStore
                {
                    ProductId = 10,
                    StoreId = 1,
                    SectorId = 6,
                    Quantity = 10,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                }
                );
        }
    }
}
