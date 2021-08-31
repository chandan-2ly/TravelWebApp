using System;
using Travel.Core.Model;
using Travel.IRepository;
using Travel.Entities;
using Travel.Entities.Entity;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Travel.Core.BusinessModels;

namespace Travel.Repository
{
    public class UserRepository : IUserRepository
    {
        #region variables
        private readonly TravelContext _travelEntities;
        #endregion

        #region constructor
        public UserRepository(TravelContext travelContext)
        {
            _travelEntities = travelContext;
        }
        #endregion

        #region methods
        public int RegisterUser(RegisterUser registerUser)
        {
            var entity = new User { 
                FirstName = registerUser.FirstName, 
                Email = registerUser.Email, 
                Password = registerUser.Password, 
                Salt = registerUser.Salt,
                Role = registerUser.Role,
                LastName = registerUser.LastName,
                CreatedOn = DateTime.UtcNow,
                ModifiedOn = DateTime.UtcNow
            };
            _travelEntities.Add(entity);
            var status = _travelEntities.SaveChanges();

            return status;
        }

        public async Task<User> GetUserByEmail(string emailId)
        {
            return await _travelEntities.Users.FirstOrDefaultAsync(x => x.Email == emailId);
        }

        public AuthenticateResponse AuthenticateUser(string email, string password)
        {
            var result = new AuthenticateResponse();
            return result;
        }

        #endregion
    }
}
