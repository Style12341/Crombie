using GestionStock.Models.Entitiy;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestionStock.Seeds
{
    public class StoreSeed : IEntityTypeConfiguration<Store>
    {
        void IEntityTypeConfiguration<Store>.Configure(EntityTypeBuilder<Store> builder)
        {
            builder.HasData(
                new Store
                {
                    Id = 1,
                    Name = "Store 1",
                    Address = "123 Main",
                    Phone = "123-456-7890",
                    Email = "test@test.com",
                    Description = "A test store.",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                }
                );
        }
    }
}
