namespace ERP.Models
{
    public class Department : AuditableEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public required string NameDepartMent { get; set; }
        public string ? Description { get; set; }

        public List<User> Users { get; set; } = [];
    }
}