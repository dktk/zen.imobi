namespace PropertyLogic.Migrations_Events
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial_Events_Push : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "events.PropertyCreated",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        PropertyId = c.Guid(nullable: false),
                        Date = c.DateTime(nullable: false),
                        UserId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
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
            DropTable("events.PropertyCreated");
        }
    }
}
