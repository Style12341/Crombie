﻿namespace GestionStock.Models.Entitiy
{
    public class Store
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }
        public ICollection<StockProductStore> Stock { get; set; } = [];

        public ICollection<Sector> Sectors { get; set; } = [];
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }


    }
}
