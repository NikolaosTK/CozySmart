namespace CozySmart.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ad : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Availabilities", "AccommodationId", "dbo.Accommodations");
            DropIndex("dbo.Availabilities", new[] { "AccommodationId" });
            DropTable("dbo.Availabilities");
        }
        
        public override void Down()
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
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.Availabilities", "AccommodationId");
            AddForeignKey("dbo.Availabilities", "AccommodationId", "dbo.Accommodations", "Id", cascadeDelete: true);
        }
    }
}
