namespace GestionStock.Models
{
    public class Store
    {
        public Guid Id { get; set; }
        public String Name { get; set; }
        public String Address { get; set; }
        public String Phone { get; set; }
        public String Email { get; set; }
        public String Description { get; set; }
        public ICollection<StockProductStore> Stock { get; set; }

        public ICollection<Sector> Sectors { get; set; }    
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }


    }
}
