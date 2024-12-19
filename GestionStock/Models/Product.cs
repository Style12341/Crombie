namespace GestionStock.Models
{
    public class Product
    {
        public Guid Id { get; set; }

        public String Name { get; set; }

        public String Description { get; set; }

        public String Code { get; set; }

        public Category Category { get; set; }
        public Guid CategoryId { get; set; }

        public ICollection<StockProductStore> Stock { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

    }
}
