using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Identity;

namespace MyFishEye.Entities.Users
{
    public class UserRole : IRole<int>
    {
        public UserRole()
        {
            Users = new HashSet<User>();
        }

        public UserRole(string roleName) : this()
        {
            Name = roleName;
        }

        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<User> Users { get; set; }
    }
}
