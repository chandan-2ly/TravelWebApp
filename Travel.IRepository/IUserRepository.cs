using System;
using System.Threading.Tasks;
using Travel.Core.BusinessModels;
using Travel.Core.Model;
using Travel.Entities.Entity;

namespace Travel.IRepository
{
    public interface IUserRepository
    {
        int RegisterUser(RegisterUser registerUser);
        Task<User> GetUserByEmail(string emailId);
        Task<User> GetUserById(Guid id);
        Task<bool> UpdateUserDetails(Guid id, UserDetails user);
        Task<bool> DeleteUserById(Guid Id);
        Task<bool> HardDeleteUserById(Guid Id);

    }
}
