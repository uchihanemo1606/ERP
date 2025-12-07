using System.ComponentModel.DataAnnotations;

namespace ERP.Models
{
    public class RefreshTokenUser
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid UserId { get; set; } 
        public User User { get; set; } = null!;
        [MaxLength(500)]
        public string Token { get; set; } = null!;
        public string AccessTokenId = null!;
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public DateTime ExpiryDate { get; set; }                    // VD: 7 ngày

        public bool IsUsed { get; set; } = false;                   // Đã dùng để lấy access token mới chưa
        public bool IsRevoked { get; set; } = false;                // Bị thu hồi (logout)

        [MaxLength(50)]
        public string? IpAddress { get; set; }

        [MaxLength(200)]
        public string? DeviceInfo { get; set; }
    }
}
