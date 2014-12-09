using System.Linq;
using MyFishEye.Entities;

namespace MyFishEye.DataAccess
{
    public class Test
    {
        public void TestDbConnection()
        {
            var db = new MyFishEyeContext();
            var test = db.Users.ToList();
        }
    }
}
