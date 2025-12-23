using System;
namespace ERP.Models
{
    public class Location : AuditableEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string LocationName { get; set; } = null!;
        public Guid WareHouseId { get; set; }
        public Warehouse Warehouse { get; set; } = null!;
        public string Type { get; set; } = null!;
        //e.g., Shelf, Bin, Zone
        public string? Description { get; set; }
        public string Shelf { get; set; } = null!;
        public string Bin { get; set; } = null!;
        public string Zone { get; set; } = null!;

    }
}