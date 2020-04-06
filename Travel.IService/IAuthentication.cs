using System;
using System.Threading.Tasks;

namespace Travel.IService
{
    public interface IAuthentication
    {
        Task AuthenticateUser(string email, string password);
    }
}
