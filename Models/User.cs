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
        public string BasicSalary { get; set; } = null!; // lương cơ bảng
        public string Allowance { get; set; } = null!; // phụ cấp
        public string Insurance { get; set; } = null!; // bảo hiểm

        public DateOnly StartDate { get; set; } // ngày bắt đầu làm việc
        public DateOnly EndDate { get; set; } // ngày kết thúc làm việc

        public bool IsActive { get; set; } = true;

        //Department
        public Guid DepartmentId { get; set; }
        public Department Department { get; set; } = null!;

        //Refresh Token 
        public List<RefreshToken> refreshTokens = [];
    }
}
