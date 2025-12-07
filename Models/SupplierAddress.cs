namespace ERP.Models
{
    public class SupplierAddress
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid SupplierId { get; set; }
        public Suppliers Supplier { get; set; } = null!;
        public string AddressName { get; set; } = null!;     // VD: "Kho Hà Nội", "Nhà máy Bình Dương"
        public string FullAddress { get; set; } = null!;
        public bool IsDefault { get; set; } = false;
    }
}
