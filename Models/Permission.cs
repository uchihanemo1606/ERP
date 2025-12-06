namespace ERP.Models
{
    public class Permission : AuditableEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();      
        public required string NamePermission { get; set; }
        public string? Description { get; set; }

    }
}
