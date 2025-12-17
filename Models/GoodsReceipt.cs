namespace ERP.Models
{
    public class GoodsReceipt
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string ReceiptNumber { get; set; } = null!;  // GR-202512-0001
        public Guid PurchaseOrderId { get; set; }
        public PurchaseOrder PurchaseOrder { get; set; } = null!;

        public Guid WarehouseId { get; set; }
        public Warehouse Warehouse { get; set; } = null!;

        public Guid? LocationId { get; set; }
        public Location? Location { get; set; }

        public DateTime ReceiptDate { get; set; } = DateTime.UtcNow;
        public string Status { get; set; } = "Completed";  // Draft, Completed, Cancelled

        public string? Notes { get; set; }

        public List<GoodsReceiptDetail> GoodsReceiptDetails { get; set; } = [];


    }
}
