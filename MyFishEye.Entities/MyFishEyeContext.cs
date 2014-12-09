using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using MyFishEye.Entities.Users;

namespace MyFishEye.Entities
{
    public class MyFishEyeContext : DbContext
    {
        public MyFishEyeContext()
            : base("MyFishEyeContext")
        {
        }

        

        #region Users
        public DbSet<User> Users { get; set; }
        public DbSet<UserGroup> UserGroups { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<UserCapability> UserCapabilities { get; set; }
        
        #endregion

        

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public static MyFishEyeContext Create()
        {
            return new MyFishEyeContext();
        }
    }
}
