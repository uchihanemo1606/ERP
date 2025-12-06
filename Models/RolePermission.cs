namespace ERP.Models
{
    public class RolePermission : AuditableEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid RoleId { get; set; }
        public Role Role { get; set; } = null!;
        public Guid PermissionId { get; set; }
        public Permission Permission { get; set; } = null!;

    }
}
 