using System;
namespace ERP.Models
{
    public class Inventory : AuditableEntity
    {
        public Guid Id { get; set; }  = Guid.NewGuid();

        //foreign key warehouse
        public Guid WareHouseId { get; set; }
        public Warehouse Warehouse { get; set; } = null!;

        //foreign key product
        public Guid ProductId { get; set; }
        public Product Product { get; set; } = null!;

        //foreign key location
        public Guid LocationId { get; set; }
        public Location Location { get; set; } = null!;

        // Quantities
        public decimal QuantityOnHand { get; set; } //total quantity in inventory
        public decimal QuantityAvailable { get; set; } // on hand - reserved
        public decimal QuantityReserved { get; set; } // quantity allocated to orders
        
        //levels
        public decimal ReorderLevel { get; set; } 
        public decimal ReorderQuantity { get; set; }

        //cost
        public decimal AverageCost { get; set; }
    }
}
