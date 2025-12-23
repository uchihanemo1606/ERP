using System;

namespace ERP.Models
{
    public class GoodsReceiptDetail
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public Guid GoodsReceiptId { get; set; }
        public GoodsReceipt GoodsReceipt { get; set; } = null!;

        public Guid PurchaseOrderDetailId { get; set; }
        public PurchaseOrderDetail PurchaseOrderDetail { get; set; } = null!;

        public Guid ProductId { get; set; }
        public Product Product { get; set; } = null!;

        public decimal QuantityReceived { get; set; }
        public decimal UnitCost { get; set; }  // Giá thực tế nhận (có thể khác PO)

        public string? LotNumber { get; set; }
        public DateTime? ExpiryDate { get; set; }

        public string? Notes { get; set; }

        public ICollection<Product> Products { get; set; } = [ ];

    }
}
