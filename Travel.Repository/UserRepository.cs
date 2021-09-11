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
            var data = await _travelEntities.Users
                .FirstOrDefaultAsync(x => x.Email.ToLower() == emailId.ToLower());
            return data;
        }

        public async Task<UserDetails> GetUserById(Guid id)
        {
            var user = await _travelEntities.Users
                .FirstOrDefaultAsync(x => x.Id == id);
            return new UserDetails() {
                Id =  user.Id,
                FirstName = user.FirstName,
                ContactNo = user.ContactNo,
                LastName = user.LastName,
                Address = user.Address,
                Province = user.Province,
                Zone = user.Zone,
                District = user.District,
                Role = user.Role,
                Email = user.Email
            };
        }

        public async Task<bool> UpdateUserDetails(Guid id, UserDetails user)
        {
            var result = await _travelEntities.Users
                .Where(x => x.Id == id)
                .UpdateFromQueryAsync(x => new User
                {
                    FirstName = user.FirstName,
                    ContactNo = user.ContactNo,
                    LastName = user.LastName,
                    Address = user.Address,
                    Province = user.Province,
                    Zone = user.Zone,
                    District = user.District,
                    ModifiedOn = DateTime.UtcNow,
                });
            return result > 0;
        }

        public async Task<bool> DeleteUserById(Guid id)
        {
            var result = await _travelEntities.Users.Where(x => x.Id == id).DeleteFromQueryAsync();
            return result > 0;
        }

        #endregion
    }
}
