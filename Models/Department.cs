
using System;
namespace ERP.Models
{
    public class Department : AuditableEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public required string NameDepartMent { get; set; }
        public string ? Description { get; set; }
        public string Abbreviation { get; set; } = null!;
        public ICollection<User> Users { get; set; } = [];
    }
}