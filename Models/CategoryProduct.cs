namespace ERP.Models
{
    public class CategoryProduct : AuditableEntity
    {
        public int Id { get; set; }
        public required string NameCategory { get; set; }
        public string? Description { get; set; }
        public List<Product> Products { get; set; } = [];
    }
}
