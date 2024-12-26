namespace GestionStock.Models.Entitiy
{
    public class Sector
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid StoreId { get; set; }
        public Store Store { get; set; }
        public ICollection<StockProductStore> Stock { get; set; } = [];
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
