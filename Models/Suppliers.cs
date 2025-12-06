using System.ComponentModel.DataAnnotations;

namespace ERP.Models
{
    public class Suppliers
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required, MaxLength(50)]
        public string Code { get; set; } = null!;           // NCC-000123

        [Required, MaxLength(300)]
        public string Name { get; set; } = null!;           // Tên công ty / cá nhân

        [MaxLength(300)]
        public string? ContactPerson { get; set; }          // Người liên hệ chính

        [MaxLength(20)]
        public string? Phone { get; set; }                  // SĐT chính

        [MaxLength(20)]
        public string? Phone2 { get; set; }                 // SĐT phụ

        [MaxLength(256)]
        public string? Email { get; set; }

        [MaxLength(50)]
        public string? TaxCode { get; set; }                // Mã số thuế (bắt buộc nếu xuất hóa đơn đỏ)

        [MaxLength(500)]
        public string? Address { get; set; }                // Địa chỉ trụ sở

        public string? Website { get; set; }

        // Công nợ & điều khoản thanh toán – CỰC KỲ QUAN TRỌNG
        public decimal CreditLimit { get; set; } = 0;       // Hạn mức công nợ được phép (VD: 500 triệu)
        public int PaymentTermDays { get; set; } = 30;      // Công nợ trả trong bao nhiêu ngày (30, 45, 60…)
        public decimal CurrentDebt { get; set; } = 0;       // Công nợ hiện tại (tính realtime)

        // Ngân hàng (rất hay dùng khi chuyển khoản)
        public string? BankName { get; set; }
        public string? BankAccountNumber { get; set; }
        public string? BankAccountName { get; set; }

        public bool IsActive { get; set; } = true;          // Còn giao dịch không
        public string? Note { get; set; }
    }
}
