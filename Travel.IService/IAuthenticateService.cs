using System;
using System.Threading.Tasks;
using Travel.Core.Model;

namespace Travel.IService
{
    public interface IAuthenticateService
    {
        Task<WebApiResponseModel> AuthenticateUser(string email, string password);
    }
}
