using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyFishEye.Entities.Users
{
    public class UserCapability
    {
        public UserCapability()
        {
            Users = new HashSet<User>();
        }

        [Key]
        public int CapabilityId { get; set; }

        public string Description { get; set; }

        public ICollection<User> Users { get; set; } 
    }
}
