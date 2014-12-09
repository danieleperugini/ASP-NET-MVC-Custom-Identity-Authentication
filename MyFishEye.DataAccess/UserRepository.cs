using MyFishEye.Entities;
using MyFishEye.Entities.Users;

namespace MyFishEye.DataAccess
{
    public class UserRepository : BaseRepository<User>
    {
        public UserRepository() { }

        public UserRepository(MyFishEyeContext db) : base(db) { }

        public User GetUserByUserName(string userName)
        {
            return GetSingle(t => t.UserName == userName);
        }

        public User GetUserByUserNameOrPassword(string userNameOrPassword)
        {
            return GetSingle(r => r.UserName.Equals(userNameOrPassword) || r.Email.Equals(userNameOrPassword));
        }

        public User GetUserByUserId(int userId)
        {
            return GetSingle(t => t.UserId == userId);
        }

    }
}
