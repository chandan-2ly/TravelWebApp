using System;
using System.Threading.Tasks;
using Travel.Core.Model;
using Travel.IService;

namespace Travel.Service
{
    public class AuthenticateService : IAuthenticateService
    {
        public WebApiResponseModel AuthenticateUser(string email, string password)
        {
            WebApiResponseModel response = new WebApiResponseModel();
            response.Message = "Hello Service Layer";
            return response;
        }
    }
}
