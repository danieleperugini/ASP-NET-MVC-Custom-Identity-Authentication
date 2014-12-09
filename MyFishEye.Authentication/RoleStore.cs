using System;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using MyFishEye.DataAccess;
using MyFishEye.Entities;
using MyFishEye.Entities.Users;

namespace MyFishEye.Authentication
{
    public class RoleStore : IRoleStore<UserRole, int>
    {
        private readonly MyFishEyeContext _db;

        public RoleStore(MyFishEyeContext db)
        {
            _db = db;
        }

        public RoleStore() : this(new MyFishEyeContext()) { }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Task CreateAsync(UserRole role)
        {
            if (role == null) throw new ArgumentNullException();

            using (var repository = new UserRoleRepository(_db))
            {
                var result = repository.Add(role);
                repository.Save();
                return Task.FromResult<object>(null);
            }
        }

        public Task UpdateAsync(UserRole role)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(UserRole role)
        {
            throw new NotImplementedException();
        }

        public Task<UserRole> FindByIdAsync(int roleId)
        {
            throw new NotImplementedException();
        }

        public Task<UserRole> FindByNameAsync(string roleName)
        {
            throw new NotImplementedException();
        }
    }

}
