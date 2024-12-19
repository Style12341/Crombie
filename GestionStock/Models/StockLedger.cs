namespace GestionStock.Models
{
    public class StockLedger
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public Product Product { get; set; }
        public Guid StoreId { get; set; }
        public Store Store { get; set; }
        public int Quantity { get; set; }
        public Action Action { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
