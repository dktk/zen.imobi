namespace PropertyLogic.Migrations_Property
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialPropertyPush : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "property.Locations",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Country = c.String(),
                        ZipCode = c.String(),
                        Street = c.String(),
                        City = c.String(),
                        Latitude = c.Long(nullable: false),
                        Longitude = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "property.Properties",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Description = c.String(),
                        Status = c.Byte(nullable: false),
                        UserId = c.Guid(nullable: false),
                        Location_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("property.Locations", t => t.Location_Id)
                .Index(t => t.Location_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("property.Properties", "Location_Id", "property.Locations");
            DropIndex("property.Properties", new[] { "Location_Id" });
            DropTable("property.Properties");
            DropTable("property.Locations");
        }
    }
}
