using GestionStock.Models.Entitiy;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestionStock.Seeds
{
    public class LedgerSeed : IEntityTypeConfiguration<StockLedger>
    {
        void IEntityTypeConfiguration<StockLedger>.Configure(EntityTypeBuilder<StockLedger> builder)
        {
            builder.HasData(
                new StockLedger
                {
                    Id = 1,
                    ProductId = 1,
                    StoreId = 1,
                    Quantity = 10,
                    Action = StockAction.Add,
                    CreatedAt = DateTime.UtcNow,
                },
                new StockLedger
                {
                    Id = 2,
                    ProductId = 2,
                    StoreId = 1,
                    Quantity = 10,
                    Action = StockAction.Add,
                    CreatedAt = DateTime.UtcNow,
                },
                new StockLedger
                {
                    Id = 3,
                    ProductId = 3,
                    StoreId = 1,
                    Quantity = 10,
                    Action = StockAction.Add,
                    CreatedAt = DateTime.UtcNow,
                },
                new StockLedger
                {
                    Id = 4,
                    ProductId = 4,
                    StoreId = 1,
                    Quantity = 10,
                    Action = StockAction.Add,
                    CreatedAt = DateTime.UtcNow,
                },
                new StockLedger
                {
                    Id = 5,
                    ProductId = 5,
                    StoreId = 1,
                    Quantity = 10,
                    Action = StockAction.Add,
                    CreatedAt = DateTime.UtcNow,
                },
                new StockLedger
                {
                    Id = 6,
                    ProductId = 6,
                    StoreId = 1,
                    Quantity = 10,
                    Action = StockAction.Add,
                    CreatedAt = DateTime.UtcNow,
                }
                );
        }
    }
}
