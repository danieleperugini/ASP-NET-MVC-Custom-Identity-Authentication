using System.Collections.Generic;
using System.Linq;
using MyFishEye.Entities;
using MyFishEye.Entities.Users;

namespace MyFishEye.DataAccess
{
    public class UserRoleRepository : BaseRepository<UserRole>
    {
        public UserRoleRepository() { }

        public UserRoleRepository(MyFishEyeContext db) : base(db) { }

        public IList<UserRole> GetUserRoles(User user)
        {
            return GetAll(t => t.Users.Select(u => u.Id).Contains(user.Id));
        }
    }
}
