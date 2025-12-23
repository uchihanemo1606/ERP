using System;
namespace ERP.Models
{
    public class Product
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public required string NameProduct { get; set; }
        public string? Description { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public string? ImageUrl { get; set; }
        public required string Supplier { get; set; }
        public required CategoryProduct CategoryProduct { get; set; }
    }
}
