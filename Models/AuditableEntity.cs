using System.ComponentModel.DataAnnotations;
using System;

namespace ERP.Models
{
    public abstract class AuditableEntity 
    {
        //Who created
        public Guid CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        //Who last modified
        public Guid? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; } = DateTime.Now;

        //who deleted
        public Guid? DeletedBy { get; set; }
        public DateTime? DeletedAt { get; set; } = DateTime.Now;

        // status 
        public bool IsDeleted { get; set; } = false;
        public bool IsActive { get; set; } = true;



    }
}
