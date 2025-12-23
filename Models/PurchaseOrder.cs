using System;
namespace ERP.Models
{
    public class PurchaseOrder
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string OrderNumber { get; set; } = null!;  // Auto: PO-202512-0001
        public Guid SupplierId { get; set; }
        public Suppliers Supplier { get; set; } = null!;

        public DateTime OrderDate { get; set; } = DateTime.UtcNow;
        public DateTime ExpectedDeliveryDate { get; set; }  // Ngày dự kiến nhận

        public string Currency { get; set; } = "VND";
        public decimal TotalAmount { get; set; }             // Tổng tiền (tính tự động)
        public decimal TaxAmount { get; set; }
        public decimal GrandTotal { get; set; }             // Total + Tax

        public string Status { get; set; } = "Draft";
        // Draft, Approved, Sent, PartiallyReceived, Received, Done, Cancelled

        public Guid? ApprovedById { get; set; }
        public User? ApprovedBy { get; set; }

        public string? Notes { get; set; }


        public ICollection<PurchaseOrderDetail> PurchaseOrderDetails { get; set; } = [];
        public ICollection<GoodsReceipt> GoodsReceipts { get; set; } = [];

    }
}
