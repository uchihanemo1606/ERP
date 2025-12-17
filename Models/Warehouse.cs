namespace ERP.Models
{
    public class Warehouse : AuditableEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string InventoryName { get; set; } = null!;
        public string Location { get; set; } = null!;
        public Guid Address { get; set; }
        public Address AddressNavigation { get; set; } = null!;
        public Guid ManagerUser { get; set; }
        public User User { get; set; } = null!;

    }
}
