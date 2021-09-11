using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Travel.Core.BusinessModels;
using Travel.Core.Model;

namespace Travel.IService
{
    public interface IUserService
    {
        public int RegisterUser(RegisterUser registerUser);
        Task<AuthenticateResponse> AuthenticateUser(string email, string password);
        Task<UserDetails> GetUserById(Guid id);
        Task<bool> UpdateUserDetails(Guid id, UserDetails user);
        Task<bool> DeleteUserById(Guid id);
    }
}
