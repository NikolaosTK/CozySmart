namespace CozySmart.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Availability : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Availabilities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AvailabilityStart = c.DateTime(nullable: false),
                        AvailabilityEnd = c.DateTime(nullable: false),
                        AccommodationId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Accommodations", t => t.AccommodationId, cascadeDelete: true)
                .Index(t => t.AccommodationId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Availabilities", "AccommodationId", "dbo.Accommodations");
            DropIndex("dbo.Availabilities", new[] { "AccommodationId" });
            DropTable("dbo.Availabilities");
        }
    }
}
