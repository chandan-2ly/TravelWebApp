using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using Travel.Core.BusinessModels;
using Travel.Entities;
using Travel.Entities.Entity;
using Travel.IRepository;

namespace Travel.Repository
{
    public class UserRepository : IUserRepository
    {
        #region variables
        private readonly TravelContext _travelContext;
        #endregion

        #region constructor
        public UserRepository(TravelContext travelContext)
        {
            _travelContext = travelContext;
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
                CreatedOn = DateTime.UtcNow
            };
            _travelContext.Add(entity);
            var status = _travelContext.SaveChanges();

            return status;
        }

        public async Task<User> GetUserByEmail(string emailId)
        {
            var user = await _travelContext.Users
                .FirstOrDefaultAsync(x => x.Email.ToLower() == emailId.ToLower());
            return user;
        }

        public async Task<User> GetUserById(Guid id)
        {
            var user = await _travelContext.Users
                .FirstOrDefaultAsync(x => x.Id == id);
            return user;
            //return new UserDetails() {
            //    Id =  user.Id,
            //    FirstName = user.FirstName,
            //    ContactNo = user.ContactNo,
            //    LastName = user.LastName,
            //    Address = user.Address,
            //    Province = user.Province,
            //    Zone = user.Zone,
            //    District = user.District,
            //    Role = user.Role,
            //    Email = user.Email
            //};
        }

        public async Task<bool> UpdateUserDetails(Guid id, UserDetails user)
        {
            var result = await _travelContext.Users
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
            var result = await _travelContext.Users
                .Where(x => x.Id == id)
                .UpdateFromQueryAsync(x => new User
                {
                    IsDeleted = true,
                    ModifiedOn = DateTime.UtcNow
                });
            return result > 0;
        }

        public async Task<bool> HardDeleteUserById(Guid id)
        {
            var user = await _travelContext.Users
                .FirstOrDefaultAsync(x => x.Id == id);
            if (user != null)
            {
                _travelContext.Users.Remove(user);
                var result = await _travelContext.SaveChangesAsync();
                return result > 0;
            }
            return false;
        }

        #endregion
    }
}
