namespace GestionStock.Models
{
    public class StockProductStore
    {
        public Guid ProductId { get; set; }
        public Product Product { get; set; }
        public Guid StoreId { get; set; }
        public Store Store { get; set; }
        public Guid SectorId { get; set; }
        public Sector Sector { get; set; }
        public int Quantity { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
