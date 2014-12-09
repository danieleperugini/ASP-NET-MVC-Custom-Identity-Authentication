using System;
using System.Collections.ObjectModel;
using System.Data.Entity.Migrations;
using System.Linq;
using MyFishEye.Entities.Users;

namespace MyFishEye.Entities.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<MyFishEye.Entities.MyFishEyeContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MyFishEye.Entities.MyFishEyeContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            context.UserRoles.Add(new UserRole
                                  {
                                      Name = "Administrator"
                                  });
            context.UserRoles.Add(new UserRole
                                  {
                                      Name = "Staff"
                                  });
            context.UserRoles.Add(new UserRole
                                  {
                                      Name = "Guest"
                                  });
            context.SaveChanges();

            var adminRole = context.UserRoles.First(t => t.Name.Equals("Administrator"));

            context.Users.Add(new User
                              {
                                  Id = Guid.NewGuid().ToString(),
                                  UserName = "dperugini",
                                  Password = "sadiker",
                                  //PasswordHash = "sadiker",
                                  Email = "perugini.daniele@gmail.com",
                                  LastPassword = "sadiker",
                                  UserRoles = new Collection<UserRole> {adminRole}
                              });
            context.SaveChanges();
        }
    }
}
