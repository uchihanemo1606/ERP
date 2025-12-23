using System;
namespace ERP.Models
{
    public class InventoryTransaction : AuditableEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string TransactionType { get; set; } = null!; // e.g., "IN", "OUT", "TRANSFER"

        //foregin key inventory
        public Guid InventoryId { get; set; }
        public Inventory Inventory { get; set; } = null!;

        //Quantity and Cost
        public decimal Quantity { get; set; }

        public decimal UnitCost { get; set; }
        public decimal TotalCost => UnitCost * Quantity;

        public DateTime TransactionDate { get; set; } = DateTime.UtcNow;

        //polymorphic reference
        public Guid ReferenceId { get; set; } // e.g., PurchaseOrderId, SalesOrderId
        public string? ReferenceType { get; set; }

        // Lot/Serial/Expiry (nếu cần theo dõi)
        public string? LotNumber { get; set; }
        public string? SerialNumber { get; set; }
        public DateTime? ExpiryDate { get; set; }


        public string? Notes { get; set; } 



    }
}
