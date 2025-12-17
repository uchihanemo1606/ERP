
using Microsoft.EntityFrameworkCore;

// Import các lớp Entity (User, Department, Account, ...)
using ERP.Models;

// Khai báo namespace của tầng Data (chỉ để quản lý code gọn hơn)
namespace ERP.Data
{
    // AppDbContext kế thừa từ DbContext → Đây là lớp làm việc trực tiếp với MySQL
    public class AppDbContext : DbContext
    {
        // Constructor của DbContext
        // DbContextOptions<AppDbContext> chứa cấu hình database (chuỗi kết nối, provider...)
        // Tham số "options" sẽ được truyền từ Program.cs khi cấu hình AddDbContext()
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) // truyền options vào DbContext gốc
        {
        }

        // DbSet<User> đại diện cho bảng Users trong MySQL.
        // Mỗi lần bạn gọi db.Users → EF hiểu bạn đang truy vấn bảng Users
        public DbSet<Address> Address { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<CategoryProduct> CategoryProducts { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<RolePermission> RolePermissions { get; set; }
        public DbSet<RefreshTokenCustomer> RefreshTokenCustomers { get; set; }
        public DbSet<RefreshTokenUser> RefreshTokenUsers { get; set; }
        public DbSet<Suppliers> Suppliers { get; set; }
        public DbSet<SupplierAddress> supplierAddresses { get; set; }
        public DbSet<SupplierContacts> SupplierContacts { get; set; }
        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<InventoryAdjustment> InventoryAdjustments { get; set; }
        public DbSet<InventoryTransaction> InventoryTransactions { get; set; }
        public DbSet<InventoryTransfer> InventoryTransfers { get; set; }
        public DbSet<Warehouse> Warehouses { get; set; }
        public DbSet<Location> Locations { get; set; }
        // Hàm cấu hình mô hình (model) và mapping sang database
        // Chạy khi EF Core build model để tạo migration hoặc chạy ứng dụng
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Gọi hàm OnModelCreating của DbContext cha để giữ cấu hình mặc định
            base.OnModelCreating(modelBuilder);

            // Cấu hình entity User
            modelBuilder.Entity<User>(entity =>
            {
                // Đặt tên bảng trong database là "Users"
                // Mặc định EF sẽ lấy tên DbSet → "Users", nhưng bạn có thể tùy chỉnh ở đây
                entity.ToTable("Users");
                // Chỉ định khóa chính của bảng → cột Id là primary key
                entity.HasKey(u => u.Id);
                entity.Property(u => u.Email).HasMaxLength(255).IsRequired();
                entity.Property(u => u.EmployeeId).HasMaxLength(100).IsRequired();
                entity.Property(u => u.FullName).HasMaxLength(255).IsRequired();
                entity.Property(u => u.Address).HasMaxLength(500);
                entity.Property(u => u.Educational).HasMaxLength(255);
                entity.Property(entity => entity.BasicSalary).HasMaxLength(100).IsRequired();

                // Bạn có thể thêm các cấu hình khác như:
                // entity.Property(u => u.Name).HasMaxLength(255).IsRequired();
                // entity.HasIndex(u => u.Email).IsUnique()
            });
        }
    }
}
