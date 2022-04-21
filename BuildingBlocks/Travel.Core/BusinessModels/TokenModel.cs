using System;

namespace Travel.Core.BusinessModels
{
    public class TokenModel
    {
        public string Token { get; set; }
        public DateTime Expiry { get; set; }
        public Guid? UserId { get; set; }
        public string Role { get; set; }
        public string Email { get; set; }
        public bool IsTokenValid { get; set; }
    }
}
