using System;
namespace ERP.Models
{
    public class SupplierAddress : AuditableEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public Guid SupplierId { get; set; }
        public Suppliers Supplier { get; set; } = null!;

        public string AddressName { get; set; } = null!;     // VD: "Trụ sở chính", "Kho Hà Nội", "Nhà máy"
        public string Street { get; set; } = null!;          // Thêm: Tách địa chỉ chi tiết để dễ tích hợp bản đồ/in hóa đơn
        public string? District { get; set; }
        public string City { get; set; } = null!;
        public string? Country { get; set; } 
        public string? ZipCode { get; set; }

        // Thay FullAddress bằng các trường riêng → tốt hơn cho báo cáo, tìm kiếm, in hóa đơn
        // public string FullAddress { get; set; } = null!;  ← XÓA

        public bool IsDefaultBilling { get; set; } = false;  // Địa chỉ xuất hóa đơn mặc định
        public bool IsDefaultShipping { get; set; } = false; // Địa chỉ giao hàng mặc định
                                                             // Có thể chỉ cần 1 IsDefault nếu muốn đơn giản, nhưng tách riêng linh hoạt hơn

        public string? Notes { get; set; }
    }
}
