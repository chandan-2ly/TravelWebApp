using AutoMapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Travel.Core.BusinessModels;
using Travel.Core.Model;
using Travel.IRepository;
using Travel.IService;

namespace Travel.Service
{
    public class UserService : IUserService
    {
        #region variables
        private readonly IUserRepository _userRepository;
        private readonly ITokenService _tokenService;
        private readonly IMapper _mapper;
        #endregion

        #region constructor
        public UserService(IUserRepository userRepository, IMapper mapper, ITokenService tokenService)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _tokenService = tokenService;
        }
        #endregion
        public int RegisterUser(RegisterUser registerUser)
        {
            //Get the salt
            registerUser.Salt = _tokenService.GenerateSalt();
            registerUser.Password = _tokenService.GenerateHash(registerUser.Password, registerUser.Salt);
            return _userRepository.RegisterUser(registerUser);
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
                var inputPassword = _tokenService.GenerateHash(password, userDetails.Salt);
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
            response.Token = _tokenService.GenerateJSONWebToken(userDetails.Email, userDetails.Id, 
                ((Constants.UserRole)userDetails.Role).ToString());
            response.IsSuccess = true;
            response.UserId = userDetails.Id;
            response.Role = userDetails.Role;
            response.Email = userDetails.Email;
            
            return response;
        }

        public async Task<UserDetails> GetUserById(Guid id)
        {
            var data = await _userRepository.GetUserById(id);
            return _mapper.Map<UserDetails>(data);
        }

        public async Task<bool> UpdateUserDetails(Guid id, UserDetails user)
        {
            return await _userRepository.UpdateUserDetails(id, user);
        }

        public async Task<bool> DeleteUserById(Guid id)
        {
            return await _userRepository.DeleteUserById(id);
        }

        public async Task<bool> HardDeleteUserById(Guid id)
        {
            return await _userRepository.DeleteUserById(id);
        }
        //private string GenerateSalt()
        //{
        //    RNGCryptoServiceProvider rNGCryptoService = new RNGCryptoServiceProvider();
        //    byte[] saltBytes = new byte[_saltByteSize];
        //    rNGCryptoService.GetBytes(saltBytes);
        //    byte[] salt = saltBytes;
        //    return Convert.ToBase64String(salt);
        //}

        //private string GenerateHash(string password, string salt)
        //{
        //    string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
        //    password: password,
        //    salt: Encoding.UTF32.GetBytes(salt),
        //    prf: KeyDerivationPrf.HMACSHA256,
        //    iterationCount: 10000,
        //    numBytesRequested: 256 / 8));

        //    return hashed;
        //}

        //private string GenerateJSONWebToken(string email, Guid userId, string role)
        //{
        //    var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["AppSettings:Token"]));
        //    var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        //    var claims = new[] {
        //    new Claim(ClaimTypes.Email, email),
        //    new Claim(ClaimTypes.Sid, userId.ToString()),
        //    new Claim(ClaimTypes.Role, role)
        //    };

        //    var tokenDescriptor = new SecurityTokenDescriptor()
        //    {
        //        Audience = "Travel",
        //        Issuer = "Self",
        //        Subject = new ClaimsIdentity(claims),
        //        Expires = DateTime.Now.AddMinutes(5),
        //        SigningCredentials = credentials
        //    };

        //    var tokenHandler = new JwtSecurityTokenHandler();
        //    var token = tokenHandler.CreateToken(tokenDescriptor);


        //    return tokenHandler.WriteToken(token);
        //}
    }
}
