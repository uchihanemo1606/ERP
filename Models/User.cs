using System;

using Microsoft.AspNetCore.Identity;

namespace ERP.Models
{
    public class User : IdentityUser
    {
        public string EmployeeId { get; set; } = null!;
        public string FullName { get; set; } = null!;
        public DateTime Birthday { get; set; }
        public string Avatar { get; set; } = "defaultavatar.png";
        public  string Educational { get; set; } = null!; // trình độ học vấn
        public string Address { get; set; } = null!; // địa chỉ
        public decimal BasicSalary { get; set; } 
        public decimal Allowance { get; set; }
        public decimal Insurance { get; set; } 

        public DateOnly StartDate { get; set; }  // ngày bắt đầu làm việc
        public DateOnly EndDate { get; set; } // ngày kết thúc làm việc

        public bool IsActive { get; set; } = true;

        //Department
        public Guid DepartmentId { get; set; }
        public Department Department { get; set; } = null!;

        //Warehouse
        public Warehouse? ManagedWarehouse { get; set; }
        //Refresh Token 
        public List<RefreshTokenUser> refreshTokenUsers = [];
    }
}
