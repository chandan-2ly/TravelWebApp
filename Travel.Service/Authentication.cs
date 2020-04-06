using System;
using System.Threading.Tasks;
using Travel.IService;

namespace Travel.Service
{
    public class Authentication : IAuthentication
    {
        public Task AuthenticateUser(string email, string password)
        {
            throw new NotImplementedException();
        }
    }
}
