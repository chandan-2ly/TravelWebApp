using System;
using System.Threading.Tasks;
using Travel.Core.Model;

namespace Travel.IService
{
    public interface IAuthentication
    {
        Task<ResponseModel> AuthenticateUser(string email, string password);
    }
}
