using System.Data.Entity.Migrations;

namespace MyFishEye.Entities.Migrations
{
    public partial class FirstShoot : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.District",
                c => new
                    {
                        DistrictId = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        Code = c.String(),
                        Region_RegionId = c.Int(),
                    })
                .PrimaryKey(t => t.DistrictId)
                .ForeignKey("dbo.Region", t => t.Region_RegionId)
                .Index(t => t.Region_RegionId);
            
            CreateTable(
                "dbo.Location",
                c => new
                    {
                        PersonLocationId = c.Int(nullable: false, identity: true),
                        Address = c.String(),
                        Latitude = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Longitude = c.Decimal(nullable: false, precision: 18, scale: 2),
                        District_DistrictId = c.Int(),
                        Person_PersonId = c.Int(),
                    })
                .PrimaryKey(t => t.PersonLocationId)
                .ForeignKey("dbo.District", t => t.District_DistrictId)
                .ForeignKey("dbo.Person", t => t.Person_PersonId)
                .Index(t => t.District_DistrictId)
                .Index(t => t.Person_PersonId);
            
            CreateTable(
                "dbo.Person",
                c => new
                    {
                        PersonId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Surname = c.String(),
                        FiscalCode = c.String(),
                        VatNumber = c.String(),
                        TelephoneNumber = c.String(),
                        MobileNumber = c.String(),
                        EmailAddress = c.String(),
                        User_UserId = c.Int(),
                    })
                .PrimaryKey(t => t.PersonId)
                .ForeignKey("dbo.User", t => t.User_UserId)
                .Index(t => t.User_UserId);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        Id = c.String(),
                        UserName = c.String(),
                        Password = c.String(),
                        LastPassword = c.String(),
                        Email = c.String(),
                        PhoneNumber = c.String(),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.UserCapability",
                c => new
                    {
                        CapabilityId = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.CapabilityId);
            
            CreateTable(
                "dbo.UserGroup",
                c => new
                    {
                        UserGroupId = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.UserGroupId);
            
            CreateTable(
                "dbo.UserRole",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Region",
                c => new
                    {
                        RegionId = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.RegionId);
            
            CreateTable(
                "dbo.Log",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Thread = c.String(),
                        Level = c.String(),
                        Logger = c.String(),
                        Message = c.String(),
                        Exception = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProductFamily",
                c => new
                    {
                        ProductFamilyId = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        ParentProductFamily_ProductFamilyId = c.Int(),
                    })
                .PrimaryKey(t => t.ProductFamilyId)
                .ForeignKey("dbo.ProductFamily", t => t.ParentProductFamily_ProductFamilyId)
                .Index(t => t.ParentProductFamily_ProductFamilyId);
            
            CreateTable(
                "dbo.Product",
                c => new
                    {
                        ProductId = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        ProductFamily_ProductFamilyId = c.Int(),
                    })
                .PrimaryKey(t => t.ProductId)
                .ForeignKey("dbo.ProductFamily", t => t.ProductFamily_ProductFamilyId)
                .Index(t => t.ProductFamily_ProductFamilyId);
            
            CreateTable(
                "dbo.ProductProperty",
                c => new
                    {
                        ProductPropertyId = c.Int(nullable: false, identity: true),
                        PropertyDescription = c.String(),
                        PropertyValue = c.String(),
                        Product_ProductId = c.Int(),
                    })
                .PrimaryKey(t => t.ProductPropertyId)
                .ForeignKey("dbo.Product", t => t.Product_ProductId)
                .Index(t => t.Product_ProductId);
            
            CreateTable(
                "dbo.ProductVariable",
                c => new
                    {
                        ProductVariableId = c.Int(nullable: false, identity: true),
                        VariableDescription = c.String(),
                        IsOptional = c.Boolean(nullable: false),
                        Product_ProductId = c.Int(),
                    })
                .PrimaryKey(t => t.ProductVariableId)
                .ForeignKey("dbo.Product", t => t.Product_ProductId)
                .Index(t => t.Product_ProductId);
            
            CreateTable(
                "dbo.UserCapabilityUser",
                c => new
                    {
                        UserCapability_CapabilityId = c.Int(nullable: false),
                        User_UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserCapability_CapabilityId, t.User_UserId })
                .ForeignKey("dbo.UserCapability", t => t.UserCapability_CapabilityId, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.User_UserId, cascadeDelete: true)
                .Index(t => t.UserCapability_CapabilityId)
                .Index(t => t.User_UserId);
            
            CreateTable(
                "dbo.UserGroupUser",
                c => new
                    {
                        UserGroup_UserGroupId = c.Int(nullable: false),
                        User_UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserGroup_UserGroupId, t.User_UserId })
                .ForeignKey("dbo.UserGroup", t => t.UserGroup_UserGroupId, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.User_UserId, cascadeDelete: true)
                .Index(t => t.UserGroup_UserGroupId)
                .Index(t => t.User_UserId);
            
            CreateTable(
                "dbo.UserRoleUser",
                c => new
                    {
                        UserRole_Id = c.Int(nullable: false),
                        User_UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserRole_Id, t.User_UserId })
                .ForeignKey("dbo.UserRole", t => t.UserRole_Id, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.User_UserId, cascadeDelete: true)
                .Index(t => t.UserRole_Id)
                .Index(t => t.User_UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProductVariable", "Product_ProductId", "dbo.Product");
            DropForeignKey("dbo.ProductProperty", "Product_ProductId", "dbo.Product");
            DropForeignKey("dbo.Product", "ProductFamily_ProductFamilyId", "dbo.ProductFamily");
            DropForeignKey("dbo.ProductFamily", "ParentProductFamily_ProductFamilyId", "dbo.ProductFamily");
            DropForeignKey("dbo.District", "Region_RegionId", "dbo.Region");
            DropForeignKey("dbo.Person", "User_UserId", "dbo.User");
            DropForeignKey("dbo.UserRoleUser", "User_UserId", "dbo.User");
            DropForeignKey("dbo.UserRoleUser", "UserRole_Id", "dbo.UserRole");
            DropForeignKey("dbo.UserGroupUser", "User_UserId", "dbo.User");
            DropForeignKey("dbo.UserGroupUser", "UserGroup_UserGroupId", "dbo.UserGroup");
            DropForeignKey("dbo.UserCapabilityUser", "User_UserId", "dbo.User");
            DropForeignKey("dbo.UserCapabilityUser", "UserCapability_CapabilityId", "dbo.UserCapability");
            DropForeignKey("dbo.Location", "Person_PersonId", "dbo.Person");
            DropForeignKey("dbo.Location", "District_DistrictId", "dbo.District");
            DropIndex("dbo.UserRoleUser", new[] { "User_UserId" });
            DropIndex("dbo.UserRoleUser", new[] { "UserRole_Id" });
            DropIndex("dbo.UserGroupUser", new[] { "User_UserId" });
            DropIndex("dbo.UserGroupUser", new[] { "UserGroup_UserGroupId" });
            DropIndex("dbo.UserCapabilityUser", new[] { "User_UserId" });
            DropIndex("dbo.UserCapabilityUser", new[] { "UserCapability_CapabilityId" });
            DropIndex("dbo.ProductVariable", new[] { "Product_ProductId" });
            DropIndex("dbo.ProductProperty", new[] { "Product_ProductId" });
            DropIndex("dbo.Product", new[] { "ProductFamily_ProductFamilyId" });
            DropIndex("dbo.ProductFamily", new[] { "ParentProductFamily_ProductFamilyId" });
            DropIndex("dbo.UserGroup", "IX_UserGroup_Description");
            DropIndex("dbo.Person", new[] { "User_UserId" });
            DropIndex("dbo.Location", new[] { "Person_PersonId" });
            DropIndex("dbo.Location", new[] { "District_DistrictId" });
            DropIndex("dbo.District", new[] { "Region_RegionId" });
            DropTable("dbo.UserRoleUser");
            DropTable("dbo.UserGroupUser");
            DropTable("dbo.UserCapabilityUser");
            DropTable("dbo.ProductVariable");
            DropTable("dbo.ProductProperty");
            DropTable("dbo.Product");
            DropTable("dbo.ProductFamily");
            DropTable("dbo.Log");
            DropTable("dbo.Region");
            DropTable("dbo.UserRole");
            DropTable("dbo.UserGroup");
            DropTable("dbo.UserCapability");
            DropTable("dbo.User");
            DropTable("dbo.Person");
            DropTable("dbo.Location");
            DropTable("dbo.District");
        }
    }
}
