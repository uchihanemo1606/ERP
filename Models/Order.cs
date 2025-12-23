using System;
namespace ERP.Models
{
    public class Order
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string Code { get; set; } = null!;           // SO-2025-000123 (mã đơn)

        public Guid CustomerId { get; set; }
        public Customer Customer { get; set; } = null!;  // KHÁCH HÀNG, không phải User!
        public DateTime OrderDate { get; set; } = DateTime.Now;
        public DateTime? ShippingDate { get; set; }         // Ngày giao dự kiến
        public DateTime? DeliveredDate { get; set; }        // Ngày giao thành công

        public string Status { get; set; } = "Draft";       // Draft, Confirmed, Shipping, Completed, Cancelled
        public string PaymentStatus { get; set; } = "Unpaid"; // Unpaid, Partial, Paid
        public string PaymentMethod { get; set; } = "Cash";   // Cash, BankTransfer, MoMo, Credit...

        public decimal TotalAmount { get; set; }            // Tổng tiền (tính từ OrderDetails)
        public decimal DiscountAmount { get; set; } = 0;    // Chiết khấu đơn hàng
        public decimal FinalAmount { get; set; }            // Tổng phải trả = Total - Discount

        public string? Note { get; set; }
        public string? ShippingAddress { get; set; }

        // Navigation
        public ICollection<OrderDetail> OrderDetails { get; set; } = [];

    }
}
