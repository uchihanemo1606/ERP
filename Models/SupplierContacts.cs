namespace ERP.Models
{
    public class SupplierContacts
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid SupplierId { get; set; }
        public Suppliers Supplier { get; set; } = null!;
        public string FullName { get; set; } = null!;
        public string? Position { get; set; }               // Kế toán, kinh doanh, giao nhận
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public bool IsPrimary { get; set; } = false;        // Người liên hệ chính
    }
}
