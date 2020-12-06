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
    }
}
