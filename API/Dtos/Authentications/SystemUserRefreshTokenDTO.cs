namespace API.Dtos.Authentications
{
    public class SystemUserRefreshTokenDTO
    {
        public int ID { get; set; }
        public string Token { get; set; } // Token cần thay thế
        public DateTime Expires { get; set; } // Ngày hết hạn
        public DateTime CreatedTime { get; set; } // Ngày tạo
        public DateTime? RevokedTime { get; set; } // Thời gian thu hồi
        public string ReplacedByToken { get; set; } // Token được thay thế
        public string ReasonRevoked { get; set; } // lý do thay thế Token
        public string Username { get; set; } // Người dùng Token
        public bool IsExpired => DateTime.UtcNow >= Expires;
        public bool IsRevoked => RevokedTime != null;
        public bool IsActive => !IsRevoked && !IsExpired;
    }
}