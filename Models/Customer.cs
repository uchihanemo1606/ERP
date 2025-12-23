
using System;
using Microsoft.AspNetCore.Identity;
namespace ERP.Models
{
    public class Customer : IdentityUser
    {
        public string FullName { get; set; } = null!;
        public string CCCD { get; set; } = null!;
        public decimal CreditLimit { get; set; } = 0;
        public decimal Debt { get; set; } = 0;
        public bool IsActive { get; set; } = true;

        // Navigation
        public ICollection<Address> Addresses { get; set; } = [];
        public ICollection<Order> Orders { get; set; } = [];
        public ICollection<RefreshTokenCustomer> RefreshTokenCustomers { get; set; } = [];


    }
}
