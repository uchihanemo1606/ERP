namespace ERP.Models
{
    public class InventoryAdjustment : AuditableEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        
        public string AdjustmentCode { get; set; } = null!;

        //foreign key warehouse
        public Guid WareHouseId { get; set; }
        public Warehouse Warehouse { get; set; } = null!;

        //foreign key product
        public Guid ProductId { get; set; }
        public Product Product { get; set; } = null!;

        //foreign key location
        public Guid LocationId { get; set; }
        public Location Location { get; set; } = null!;

        // Quantity adjustment
        public decimal QuantityAdjusted { get; set; }
        public string Reason { get; set; } = null!;

        public Guid ApprovedBy { get; set; }
        public User User { get; set; } = null!;

        public string Status { get; set; } = null!; //e.g., Pending, Approved, Rejected

    }
}
