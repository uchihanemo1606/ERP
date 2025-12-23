using System;
namespace ERP.Models
{
    public class OrderDetail : AuditableEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid OrderId { get; set; }
        public virtual Order Order { get; set; } = null!;

        public Guid ProductId { get; set; }
        public virtual Product Product { get; set; } = null!;

        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }              // Giá bán tại thời điểm
        public decimal Discount { get; set; } = 0;          // Chiết khấu từng dòng
        public decimal TotalAmount => Quantity * UnitPrice - Discount;
    }
}
