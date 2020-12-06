using System.Threading.Tasks;
using Travel.Core.BusinessModels;
using Travel.Core.Model;
using Travel.Entities.Entity;

namespace Travel.IRepository
{
    public interface IUserRepository
    {
        public int RegisterUser(RegisterUser registerUser);
        public Task<User> GetUser(string EmailId);
        AuthenticateResponse AuthenticateUser(string email, string password);
    }
}
