using System;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using MyFishEye.DataAccess;
using MyFishEye.Entities;
using MyFishEye.Entities.Users;

namespace MyFishEye.Authentication
{
    public class UserStore : 
        IUserStore<User, string>, 
        IUserLockoutStore<User, string>, 
        IUserPasswordStore<User, string>, 
        IUserTwoFactorStore<User, string>
    {

         private readonly MyFishEyeContext _db;

        public UserStore(MyFishEyeContext db)
        {
            _db = db;
        }

        public UserStore() : this(new MyFishEyeContext()) { }


        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Task CreateAsync(User user)
        {
            if (user == null) throw new ArgumentNullException();

            using (var repository = new UserRepository(_db))
            {
                repository.Add(user);
                repository.Save();
            }

            return Task.FromResult<object>(null);
        }

        public Task UpdateAsync(User user)
        {
            if (user == null) throw new ArgumentNullException();

            using (var repository = new UserRepository(_db))
            {
                repository.Edit(user);
                repository.Save();
            }

            return Task.FromResult<object>(null);
        }

        public Task DeleteAsync(User user)
        {
            if (user == null) throw new ArgumentNullException();

            using (var repository = new UserRepository(_db))
            {
                repository.Delete(user);
                repository.Save();
            }

            return Task.FromResult<object>(null);
        }

        public Task<User> FindByIdAsync(string userId)
        {
            User user;
            using (var repository = new UserRepository(_db))
            {
                user = repository.GetSingle(t=> t.Id == userId);
            }

            return Task.FromResult(user);
        }

        public Task<User> FindByNameAsync(string userName)
        {
            if (String.IsNullOrEmpty(userName)) throw new ArgumentNullException();

            User user;
            using (var repository = new UserRepository(_db))
            {
                user = repository.GetUserByUserNameOrPassword(userName);
            }

            return Task.FromResult(user);
        }

        public Task<User> FindByIdAsync(int userId)
        {
            User user;
            using (var repository = new UserRepository(_db))
            {
                user = repository.GetSingle(userId);
            }

            return Task.FromResult(user);
        }

        

        #region IUserLockOut
        public Task<DateTimeOffset> GetLockoutEndDateAsync(User user)
        {
            throw new NotImplementedException();
        }

        public Task SetLockoutEndDateAsync(User user, DateTimeOffset lockoutEnd)
        {
            throw new NotImplementedException();
        }

        public Task<int> IncrementAccessFailedCountAsync(User user)
        {
            throw new NotImplementedException();
        }

        public Task ResetAccessFailedCountAsync(User user)
        {
            throw new NotImplementedException();
        }

        public Task<int> GetAccessFailedCountAsync(User user)
        {
            throw new NotImplementedException();
        }

        public Task<bool> GetLockoutEnabledAsync(User user)
        {
            return Task.FromResult(false);
            
        }

        public Task SetLockoutEnabledAsync(User user, bool enabled)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region IUserPasswordStore
        public Task SetPasswordHashAsync(User user, string passwordHash)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetPasswordHashAsync(User user)
        {
            if (user == null) throw new ArgumentNullException();

            return Task.FromResult(user.Password);
            
        }

        public Task<bool> HasPasswordAsync(User user)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region IUserTwoFactorStore
        public Task SetTwoFactorEnabledAsync(User user, bool enabled)
        {
            return Task.FromResult(false);
        }

        public Task<bool> GetTwoFactorEnabledAsync(User user)
        {
            return Task.FromResult(false);
        }
        #endregion
    }
}
