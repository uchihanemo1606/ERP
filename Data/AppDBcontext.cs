using Microsoft.EntityFrameworkCore;
using ERP.Models;

namespace ERP.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // DbSet - Tên nhất quán
        public DbSet<Address> Addresses { get; set; }
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
        public DbSet<SupplierAddress> SupplierAddresses { get; set; }
        public DbSet<SupplierContacts> SupplierContacts { get; set; }
        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<InventoryAdjustment> InventoryAdjustments { get; set; }
        public DbSet<InventoryTransaction> InventoryTransactions { get; set; }
        public DbSet<InventoryTransfer> InventoryTransfers { get; set; }
        public DbSet<Warehouse> Warehouses { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<GoodsReceipt> GoodsReceipts { get; set; }
        public DbSet<GoodsReceiptDetail> GoodsReceiptDetails { get; set; }
        public DbSet<PurchaseOrder> PurchaseOrders { get; set; }
        public DbSet<PurchaseOrderDetail> PurchaseOrderDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Global decimal precision 18,4 cho số lượng/giá vốn
            foreach (var property in modelBuilder.Model.GetEntityTypes()
                .SelectMany(t => t.GetProperties())
                .Where(p => p.ClrType == typeof(decimal) || p.ClrType == typeof(decimal?)))
            {
                property.SetColumnType("decimal(18,4)");
            }

            // ==================== USER & CUSTOMER ====================
            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("Users");
                entity.HasKey(u => u.Id);
                entity.Property(u => u.Email).HasMaxLength(255).IsRequired();
                entity.HasIndex(u => u.Email).IsUnique();
                entity.Property(u => u.EmployeeId).HasMaxLength(100).IsRequired();
                entity.Property(u => u.FullName).HasMaxLength(255).IsRequired();
                entity.Property(u => u.Address).HasMaxLength(500);
                entity.Property(u => u.Educational).HasMaxLength(255);
                entity.Property(u => u.PasswordHash).IsRequired();
            });

            modelBuilder.Entity<Address>(entity =>
            {
                entity.ToTable("Addresses");
                entity.HasKey(a => a.Id);
                entity.Property(a => a.Country).HasMaxLength(100);
                entity.Property(a => a.State).HasMaxLength(100);
                entity.Property(a => a.City).HasMaxLength(100);
                entity.Property(a => a.Street).HasMaxLength(500);
                entity.HasOne(a => a.Customer)
                      .WithMany(c => c.Addresses)
                      .HasForeignKey(a => a.CustomerId)  // ĐÚNG: FK ở Address
                      .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("Customers");
                entity.HasKey(c => c.Id);
                entity.Property(c => c.FullName).HasMaxLength(255);
                entity.Property(c => c.CCCD).HasMaxLength(50);
                entity.Property(c => c.IsActive).HasDefaultValue(true);
            });

            // ==================== SUPPLIER ====================
            modelBuilder.Entity<Suppliers>(entity =>
            {
                entity.ToTable("Suppliers");
                entity.HasKey(s => s.Id);
                entity.Property(s => s.Code).HasMaxLength(50);
                entity.Property(s => s.Name).HasMaxLength(255).IsRequired();
                entity.HasIndex(s => s.Code).IsUnique();
            });

            modelBuilder.Entity<SupplierAddress>(entity =>
            {
                entity.ToTable("SupplierAddresses");
                entity.HasKey(sa => sa.Id);
                entity.HasOne(sa => sa.Supplier)
                      .WithMany(s => s.SupplierAddresses)
                      .HasForeignKey(sa => sa.SupplierId)  // ĐÚNG: FK ở SupplierAddress
                      .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<SupplierContacts>(entity =>
            {
                entity.ToTable("SupplierContacts");
                entity.HasKey(sc => sc.Id);
                entity.Property(sc => sc.Phone).HasMaxLength(20);
                entity.Property(sc => sc.Email).HasMaxLength(255);
                entity.HasOne(sc => sc.Supplier)
                      .WithMany(s => s.SupplierContacts)
                      .HasForeignKey(sc => sc.SupplierId)  // ĐÚNG: FK ở SupplierContacts
                      .OnDelete(DeleteBehavior.Cascade);
            });

            // ==================== WAREHOUSE & LOCATION ====================
            modelBuilder.Entity<Warehouse>(entity =>
            {
                entity.ToTable("Warehouses");
                entity.HasKey(w => w.Id);
                entity.Property(w => w.WarehouseName).HasMaxLength(100);
                entity.Property(w => w.Address).HasMaxLength(300);
                // Sửa lỗi: HasOne(w => w.User) → HasOne(w => w.ManagerUser)
                entity.HasOne(w => w.ManagerUser)
                  .WithOne(u => u.ManagedWarehouse)
                  .HasForeignKey<Warehouse>(w => w.ManagerUserId)  // string
                  .OnDelete(DeleteBehavior.Restrict)
                  .IsRequired();
            });

            modelBuilder.Entity<Location>(entity =>
            {
                entity.ToTable("Locations");
                entity.HasKey(l => l.Id);
                entity.Property(l => l.Type).HasMaxLength(50);
                entity.Property(l => l.LocationName).HasMaxLength(255);
                // Sửa lỗi: HasOne(w => w.Warehouse) → HasOne(l => l.Warehouse)
                entity.HasOne(l => l.Warehouse)  // ĐÚNG: l (Location)
                      .WithMany()
                      .HasForeignKey(l => l.WareHouseId)  // ĐÚNG: FK ở Location
                      .OnDelete(DeleteBehavior.Restrict);
            });

            // ==================== INVENTORY - CỐT LÕI ====================
            modelBuilder.Entity<Inventory>(entity =>
            {
                entity.ToTable("Inventories");
                entity.HasKey(i => i.Id);

                // Sửa lỗi: HasForeignKey(w => w.WareHouseId) → i => i.WarehouseId
                entity.HasOne(i => i.Warehouse)
                      .WithMany()
                      .HasForeignKey(i => i.WareHouseId)  // ĐÚNG: i (Inventory)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(i => i.Product)
                      .WithMany()
                      .HasForeignKey(i => i.ProductId)  // ĐÚNG
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(i => i.Location)
                      .WithMany()
                      .HasForeignKey(i => i.LocationId)
                      .OnDelete(DeleteBehavior.SetNull)
                      .IsRequired(false);

                // Unique constraint - QUAN TRỌNG NHẤT!
                entity.HasIndex(i => new { i.WareHouseId, i.ProductId, i.LocationId }).IsUnique();
            });

            // ==================== PURCHASE & GOODS RECEIPT ====================
            modelBuilder.Entity<PurchaseOrder>(entity =>
            {
                entity.ToTable("PurchaseOrders");
                entity.HasKey(po => po.Id);
                entity.Property(po => po.OrderNumber).HasMaxLength(100);
                entity.HasIndex(po => po.OrderNumber).IsUnique();
                entity.HasOne(po => po.Supplier)
                      .WithMany()
                      .HasForeignKey(po => po.SupplierId)
                      .OnDelete(DeleteBehavior.Restrict);
                entity.HasMany(po => po.PurchaseOrderDetails)
                      .WithOne(pod => pod.PurchaseOrder)
                      .HasForeignKey(pod => pod.PurchaseOrderId)  // ĐÚNG
                      .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<PurchaseOrderDetail>(entity =>
            {
                entity.ToTable("PurchaseOrderDetails");
                entity.HasKey(pod => pod.Id);
            });

            modelBuilder.Entity<GoodsReceipt>(entity =>
            {
                entity.ToTable("GoodsReceipts");
                entity.HasKey(gr => gr.Id);
                entity.Property(gr => gr.ReceiptNumber).HasMaxLength(100);
                entity.HasIndex(gr => gr.ReceiptNumber).IsUnique();
                entity.HasOne(gr => gr.PurchaseOrder)
                      .WithMany(po => po.GoodsReceipts)
                      .HasForeignKey(gr => gr.PurchaseOrderId)  // ĐÚNG
                      .OnDelete(DeleteBehavior.Restrict);
                entity.HasOne(gr => gr.Warehouse)
                      .WithMany()
                      .HasForeignKey(gr => gr.WarehouseId)  // ĐÚNG
                      .OnDelete(DeleteBehavior.Restrict);
                entity.HasMany(gr => gr.GoodsReceiptDetails)
                      .WithOne(d => d.GoodsReceipt)
                      .HasForeignKey(d => d.GoodsReceiptId)  // ĐÚNG
                      .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<GoodsReceiptDetail>(entity =>
            {
                entity.ToTable("GoodsReceiptDetails");
                entity.HasKey(d => d.Id);
            });

            // Các entity cơ bản khác
            modelBuilder.Entity<CategoryProduct>(e => { e.ToTable("CategoryProducts"); e.HasKey(c => c.Id); });
            modelBuilder.Entity<Department>(e => { e.ToTable("Departments"); e.HasKey(d => d.Id); });
            modelBuilder.Entity<Permission>(e => { e.ToTable("Permissions"); e.HasKey(p => p.Id); });
            modelBuilder.Entity<Role>(e => { e.ToTable("Roles"); e.HasKey(r => r.Id); });
            modelBuilder.Entity<RolePermission>(e => { e.ToTable("RolePermissions"); e.HasKey(rp => rp.Id); });
            modelBuilder.Entity<RefreshTokenCustomer>(e => { e.ToTable("RefreshTokenCustomers"); e.HasKey(rt => rt.Id); });
            modelBuilder.Entity<RefreshTokenUser>(e => { e.ToTable("RefreshTokenUsers"); e.HasKey(rt => rt.Id); });
            modelBuilder.Entity<InventoryAdjustment>(e => { e.ToTable("InventoryAdjustments"); e.HasKey(a => a.Id); });
            modelBuilder.Entity<InventoryTransaction>(e => { e.ToTable("InventoryTransactions"); e.HasKey(t => t.Id); });
            modelBuilder.Entity<InventoryTransfer>(e => { e.ToTable("InventoryTransfers"); e.HasKey(it => it.Id); });
        }
    }
}