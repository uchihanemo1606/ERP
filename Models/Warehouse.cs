using System;
namespace ERP.Models
{
    public class Warehouse : AuditableEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string WarehouseName { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string ManagerUserId { get; set; } =null!;
        public User ManagerUser { get; set; } = null!;


        public ICollection<Inventory> Inventories { get; set; } = [];
    }
}
