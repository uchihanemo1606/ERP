using System;
namespace ERP.Models
{
    public class Role : AuditableEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public required string NameRole { get; set; }
        public string? Description { get; set; }


        public ICollection<Permission> Permissions { get; set; } = [];
        public ICollection<RolePermission> RolePermissions { get; set; } = [];
    }
}
