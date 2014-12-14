namespace PropertyLogic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "events.PropertyRented",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        PropertyId = c.Guid(nullable: false),
                        Date = c.DateTime(nullable: false),
                        UserId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("events.PropertyRented");
        }
    }
}
