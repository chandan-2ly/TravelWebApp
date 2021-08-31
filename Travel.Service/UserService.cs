﻿using System;
using Travel.Core.Model;
using Travel.IService;
using Travel.IRepository;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using Travel.Core.BusinessModels;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;

namespace Travel.Service
{
    public class UserService : IUserService
    {
        #region variables
        private readonly IUserRepository _userRepository;
        private readonly int _saltByteSize = 32;
        private IConfiguration _configuration;
        #endregion

        #region constructor
        public UserService(IUserRepository userRepository, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _configuration = configuration;
        }
        #endregion
        public int RegisterUser(RegisterUser registerUser)
        {
            //Get the salt
            registerUser.Salt = GenerateSalt();
            registerUser.Password = GenerateHash(registerUser.Password, registerUser.Salt);
            return _userRepository.RegisterUser(registerUser);
        }

        private string GenerateSalt()
        {
            RNGCryptoServiceProvider rNGCryptoService = new RNGCryptoServiceProvider();
            byte[] saltBytes = new byte[_saltByteSize];
            rNGCryptoService.GetBytes(saltBytes);
            byte[] salt = saltBytes;
            return Convert.ToBase64String(salt);
        }

        private string GenerateHash(string password, string salt)
        {
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
            password: password,
            salt: Encoding.UTF32.GetBytes(salt),
            prf: KeyDerivationPrf.HMACSHA256,
            iterationCount: 10000,
            numBytesRequested: 256 / 8));

            return hashed;
        }

        public async Task<AuthenticateResponse> AuthenticateUser(string email, string password)
        {
            List<ResponseModel> errorMessage = new List<ResponseModel>();
            AuthenticateResponse response = new AuthenticateResponse();
            
            var userDetails = await _userRepository.GetUserByEmail(email);

            if (userDetails == null || userDetails.Id == Guid.Empty || userDetails.IsDeleted)
            {
                errorMessage.Add(new ResponseModel { IsSuccess = false, Message = MessageConstants.InvalidCredential });
            }
            else
            {
                //compare the password
                var inputPassword = GenerateHash(password, userDetails.Salt);
                if (inputPassword != userDetails.Password)
                {
                    errorMessage.Add(new ResponseModel { IsSuccess = false, Message = MessageConstants.InvalidCredential });
                }
            }

            if(errorMessage.Count > 0)
            {
                response.ErrorList = errorMessage;
                response.IsSuccess = false;
                return response;
            }
            
            //frame the response model
            response.Token = GenerateJSONWebToken(userDetails.Email, userDetails.Id, ((Constants.UserRole)userDetails.Role).ToString());
            response.IsSuccess = true;
            response.UserId = userDetails.Id;
            response.Role = userDetails.Role;
            response.Email = userDetails.Email;
            
            return response;
        }

        private string GenerateJSONWebToken(string email, Guid userId, string role)
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
    }
}
