namespace PropertyLogic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCommit : DbMigration
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
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("property.Properties");
            DropTable("property.Locations");
        }
    }
}
