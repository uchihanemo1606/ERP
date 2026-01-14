using System.ComponentModel.DataAnnotations;

namespace ERP.DTOs
{
    public class CreateUserDTO
    {

        [Required(ErrorMessage = "Tên đăng nhập là bắt buộc")]
        [StringLength(50, MinimumLength = 3)]
        public string Username { get; set; } = null!;

        [Required]
        [MinLength(6, ErrorMessage = "Mật khẩu phải từ 6 ký tự")]
        public string Password { get; set; } = null!;

        [Required]
        [EmailAddress(ErrorMessage = "Địa chỉ email không hợp lệ")]
        public string Email { get; set; } = null!;

        [Required]
        public string FullName { get; set; } = null!;
        public DateTime Birthday { get; set; }
        public string Educational { get; set; } = null!;
        public string Address { get; set; } = null!;

        [Required]
        public decimal BasicSalary { get; set; }

        [Required]
        public decimal Allowance { get; set; }

        [Required]
        public decimal Insurance { get; set; }

        [Required]
        public DateOnly StartDate { get; set; }
        public Guid DepartmentId { get; set; }

    }
}
