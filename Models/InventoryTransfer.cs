using System;
namespace ERP.Models
{
    public class InventoryTransfer
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string TransferCode { get; set; } = null!;

        //from warehouse
        public Guid FromWarehouseId { get; set; }
        public Warehouse FromWarehouse { get; set; } = null!;

        //to warehouse
        public Guid ToWarehouseId { get; set; }
        public Warehouse ToWarehouse { get; set; } = null!;

        public decimal Quantity { get; set; }
        public DateTime TransferDate   { get; set; }
        public string Status { get; set; } = null!;
        public string? Notes { get; set; }


    }
}
