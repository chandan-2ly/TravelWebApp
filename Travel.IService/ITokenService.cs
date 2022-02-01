using System;
using Travel.Core.BusinessModels;

namespace Travel.IService
{
    public interface ITokenService
    {
        string GenerateJSONWebToken(string email, Guid userId, string role);
        string GenerateSalt();
        string GenerateHash(string password, string salt);
        TokenModel ValidateToken(TokenModel tokenModel);
        string RefreshJSONWebToken(TokenModel tokenModel);
    }
}