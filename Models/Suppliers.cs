using System.ComponentModel.DataAnnotations;
using System;

namespace ERP.Models
{
    public class Suppliers : AuditableEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string Code { get; set; } = null!;                    // NCC-000123 
        public string Name { get; set; } = null!;                    // Tên công ty 
        public string? TaxCode { get; set; }                         // Mã số thuế 
        public string? Website { get; set; }                         // Thêm: Website công ty (hữu ích khi tra cứu)

        // === Công nợ & Điều khoản thanh toán (rất quan trọng cho mua hàng) ===
        public decimal CreditLimit { get; set; } = 0;                // Hạn mức công nợ tối đa 
        public int PaymentTermDays { get; set; } = 30;               // Số ngày được nợ (30, 45, 60...) 
        public string PaymentTermDescription { get; set; } = "Net 30"; // Mô tả rõ hơn: "Net 30", "COD", "T/T 15 days" 

        // === Thông tin ngân hàng (rất hay dùng) ===
        public string? BankName { get; set; }
        public string? BankAccountNumber { get; set; }
        public string? BankAccountName { get; set; }

        public string? CurrencyCode { get; set; } = "VND";           
        public string? Notes { get; set; }                           // Ghi chú


        public ICollection<SupplierAddress> SupplierAddresses { get; set; } = [];
        public ICollection<SupplierContacts> SupplierContacts { get; set; } = [];


    }
}
