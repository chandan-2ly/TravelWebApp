using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Travel.Core.BusinessModels;
using Travel.IService;

namespace Travel.Service
{
    public class TokenService : ITokenService
    {
        private readonly int _saltByteSize = 32;
        private IConfiguration _configuration;

        public TokenService(IConfiguration configuration)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }
        
        public string GenerateJSONWebToken(string email, Guid userId, string role)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["AppSettings:Token"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[] {
            new Claim(ClaimTypes.Email, email),
            new Claim(ClaimTypes.Sid, userId.ToString()),
            new Claim(ClaimTypes.Role, role)
            };

            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Audience = "Travel",
                Issuer = "Self",
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddMinutes(5),
                SigningCredentials = credentials
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);


            return tokenHandler.WriteToken(token);
        }
        public TokenModel ValidateToken(TokenModel tokenModel)
        {
            if(tokenModel.Token == null)
            {
                return new TokenModel { IsTokenValid = false };
            }
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_configuration["AppSettings:Token"]);
                tokenHandler.ValidateToken(tokenModel.Token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidAudience = "Travel",
                    ValidIssuer = "Self",
                    // set clockskew to zero so tokens expire exactly at token expiration time (instead of 5 minutes later)
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);
                
                var jwtToken = (JwtSecurityToken)validatedToken;
                var userId = jwtToken.Claims.First(x => x.Type == ClaimTypes.Sid).Value;
                var role = jwtToken.Claims.First(x => x.Type == "role").Value;
                var email = jwtToken.Claims.First(x => x.Type == "email").Value;

                return new TokenModel { Token = tokenModel.Token, UserId = Guid.Parse(userId), Role = role, 
                    Email = email, Expiry = DateTime.Now, IsTokenValid = true };
            }
            catch(SecurityTokenExpiredException ex)
            {
                throw new Exception("Token Expired");
            }
        }

        public string GenerateSalt()
        {
            RNGCryptoServiceProvider rNGCryptoService = new RNGCryptoServiceProvider();
            byte[] saltBytes = new byte[_saltByteSize];
            rNGCryptoService.GetBytes(saltBytes);
            byte[] salt = saltBytes;
            return Convert.ToBase64String(salt);
        }

        public string GenerateHash(string password, string salt)
        {
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
            password: password,
            salt: Encoding.UTF32.GetBytes(salt),
            prf: KeyDerivationPrf.HMACSHA256,
            iterationCount: 10000,
            numBytesRequested: 256 / 8));

            return hashed;
        }

        public string RefreshJSONWebToken(TokenModel tokenModel)
        {
            return GenerateJSONWebToken(tokenModel.Email, (Guid)tokenModel.UserId, tokenModel.Role);
        }
    }
}
