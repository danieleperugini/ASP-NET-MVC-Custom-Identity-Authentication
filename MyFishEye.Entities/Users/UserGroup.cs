using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyFishEye.Entities.Users
{
    public sealed class UserGroup
    {
        public UserGroup()
        {
            Users = new HashSet<User>();
        }

        [Key]
        public int UserGroupId { get; set; }

        public string Description { get; set; }

        public ICollection<User> Users { get; set; }
    }
}
