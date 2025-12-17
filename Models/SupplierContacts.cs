namespace ERP.Models
{
    public class SupplierContacts
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public Guid SupplierId { get; set; }
        public Suppliers Supplier { get; set; } = null!;

        public string FullName { get; set; } = null!;
        public string? Department { get; set; }       
        public string? Phone { get; set; }
        public string? Mobile { get; set; }             // Thêm: SĐT di động riêng (thường dùng nhiều hơn)
        public string? Email { get; set; }
        public bool IsPrimary { get; set; } = false;    // Người liên hệ chính 
        public string? Notes { get; set; }              
    }
}
