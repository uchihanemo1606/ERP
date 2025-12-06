namespace ERP.Models
{
    public class Account  
    {
        public Guid Id { get; set; }
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Role { get; set; } = null!;
        public string Email { get; set; } = null!;
        public bool IsActive { get; set; } = true;


        //OTP codes
        public string? OtpVerifyEmail { get; set; }
        public string? OtpResetPassword { get; set; }

        //expiration time OTP
        public DateTime OtpVerifyEmailExpiration { get; set; }
        public DateTime OtpResetPasswordExpiration { get; set; }
    }
}
