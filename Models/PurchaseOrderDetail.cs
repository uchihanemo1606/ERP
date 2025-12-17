namespace ERP.Models
{
    public class PurchaseOrderDetail
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public Guid PurchaseOrderId { get; set; }
        public PurchaseOrder PurchaseOrder { get; set; } = null!;
        public Guid ProductId { get; set; }
        public Product Product { get; set; } = null!;
        public decimal Quantity { get; set; }
        public decimal UnitPrice { get; set; }      // Giá mua chưa thuế
        public decimal TaxRate { get; set; } = 10;  // % VAT
        public decimal LineTotal { get; set; }      // Quantity * UnitPrice
        public decimal LineTax { get; set; }
        public decimal LineGrandTotal { get; set; }
        public decimal ReceivedQuantity { get; set; } = 0;  // Đã nhận bao nhiêu
        public string? Notes { get; set; }
    }
}
