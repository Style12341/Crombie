using GestionStock.Models.Entitiy;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestionStock.Seeds
{
    public class CategorySeed : IEntityTypeConfiguration<Category>
    {
        void IEntityTypeConfiguration<Category>.Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(
                new Category
                {
                    Id = 1,
                    Name = "Electronics",
                },
                new Category
                {
                    Id = 2,
                    Name = "Clothing",
                },
                new Category
                {
                    Id = 3,
                    Name = "Food",
                },
                new Category
                {
                    Id = 4,
                    Name = "Books",
                },
                new Category
                {
                    Id = 5,
                    Name = "Furniture",
                },
                new Category
                {
                    Id = 6,
                    Name = "Toys",
                }
                );
        }
    }
}
