﻿namespace GestionStock.Models.Entitiy
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Code { get; set; }

        public Category Category { get; set; }
        public int CategoryId { get; set; }

        public ICollection<StockProductStore> Stock { get; set; } = [];

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

    }
}
