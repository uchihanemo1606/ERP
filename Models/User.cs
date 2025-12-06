namespace ERP.Models
{
    public class User
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public required string FullName { get; set; }
        public required string Email { get; set; }
        public string? EmailConfirmed { get; set; }
        public required string PhoneNumber { get; set; }
        public required string Educational { get; set; }
        public required string Address { get; set; }
        public required string BasicSalary { get; set; } // lương cơ bảng
        public required string Allowance { get; set; } // phụ cấp
        public required string Insurance { get; set; } // bảo hiểm
        public required DateOnly StartDate { get; set; }
        public required DateOnly EndDate { get; set; }

        //Department
        public Guid DepartmentId { get; set; }
        public required Department Department { get; set; } 


    }
}
