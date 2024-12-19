namespace GestionStock.Models
{
    public class Category
    {
        public Guid Id { get; set; }
        public String Name { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
