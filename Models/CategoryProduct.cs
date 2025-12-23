using System;
using System.Collections.Generic;
namespace ERP.Models
{
    public class CategoryProduct : AuditableEntity
    {
        public int Id { get; set; }
        public required string NameCategory { get; set; }
        public string? Description { get; set; }
        public ICollection<Product> Products { get; set; } = [];
    }
}
