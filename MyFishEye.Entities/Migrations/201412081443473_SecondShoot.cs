using System.Data.Entity.Migrations;

namespace MyFishEye.Entities.Migrations
{
    public partial class SecondShoot : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.UserGroup", "IX_UserGroup_Description");
        }
        
        public override void Down()
        {
            CreateIndex("dbo.UserGroup", "Description", unique: true, name: "IX_UserGroup_Description");
        }
    }
}
