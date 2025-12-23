using System;
namespace ERP.Models
{
    public class Address : AuditableEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string CustomerId { get; set; } = null!;
        public Customer Customer { get; set; } = null!;
        public string Country { get; set; } = null!;
        public string State { get; set; } = null!;
        public string City { get; set; } = null!;
        public string Street { get; set; } = null!;
         

    }
}
