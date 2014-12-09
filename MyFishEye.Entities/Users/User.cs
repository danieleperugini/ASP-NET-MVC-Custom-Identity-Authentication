using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Identity;

namespace MyFishEye.Entities.Users
{
    public class User : IUser<string>
    {
        public User()
        {
            Capabilities = new HashSet<UserCapability>();
            UserGroups = new HashSet<UserGroup>();
            UserRoles = new HashSet<UserRole>();
        }

        [Key]
        public int UserId { get; set; }
        public string Id { get; set; }

        //[Index("IX_User_Username", 1, IsUnique = true)]
        public string UserName { get; set; }
        public string Password { get; set; }
        public string LastPassword { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        //user groups customer tech ecc...
        public ICollection<UserGroup> UserGroups { get; set; }

        //user capabilities: can edit this...can create that
        public ICollection<UserCapability> Capabilities { get; set; }

        //user roles: in the system...administrator...contributor...ecc
        public ICollection<UserRole> UserRoles { get; set; } 


    }
}