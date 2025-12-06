namespace ERP.Models
{
    public class Customer
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string FullName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string CCCD { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public decimal CreditLimit { get; set; } = 0;
        public decimal Debt { get; set; } = 0;
        public bool IsActive { get; set; } = true;

        // Navigation
        public List<Address> Addresses { get; set; } = [];
        public List<Order> Orders { get; set; } = [];

    }
}
