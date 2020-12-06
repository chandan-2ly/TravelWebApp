using System;
using Travel.Core.Model;
using Travel.IService;
using Travel.IRepository;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using Travel.Core.BusinessModels;

namespace Travel.Service
{
    public class UserService : IUserService
    {
        #region variables
        private readonly IUserRepository _userRepository;
        private readonly int _saltByteSize = 32;
        #endregion

        #region constructor
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
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
            //ListResponseModel response = new ListResponseModel();
            List<ResponseModel> errorMessage = new List<ResponseModel>();
            AuthenticateResponse response = new AuthenticateResponse();
            
            //response.Message = "Hello Service Layer";
            //return response;
            var userDetails = await _userRepository.GetUser(email);

            if (userDetails.Id == Guid.Empty)
            {
                errorMessage.Add(new ResponseModel { IsSuccess = false, Message = MessageConstants.InvalidCredential });
            }

            //compare the password
            var inputPassword = GenerateHash(password, userDetails.Salt);
            if (inputPassword != userDetails.Password)
            {
                errorMessage.Add(new ResponseModel { IsSuccess = false, Message = MessageConstants.InvalidCredential });
            }

            if(errorMessage.Count > 0)
            {
                response.ErrorList = errorMessage;
                return response;
            }
            return _userRepository.AuthenticateUser(email, password);
        }
    }
}
