namespace CozySmart.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BasicUpdate2 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Features", newName: "Amenities");
            RenameColumn(table: "dbo.AccommodationFeatures", name: "FeatureId", newName: "AmenityId");
            RenameIndex(table: "dbo.AccommodationFeatures", name: "IX_FeatureId", newName: "IX_AmenityId");
            CreateTable(
                "dbo.Bookings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AccommodationId = c.Int(nullable: false),
                        Arrival = c.DateTime(nullable: false),
                        Departure = c.DateTime(nullable: false),
                        Occupancy = c.Int(nullable: false),
                        Rating = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Accommodations", t => t.AccommodationId, cascadeDelete: true)
                .Index(t => t.AccommodationId);
            
            CreateTable(
                "dbo.Images",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ImageUrl = c.String(nullable: false),
                        AccommodationId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Accommodations", t => t.AccommodationId, cascadeDelete: true)
                .Index(t => t.AccommodationId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Images", "AccommodationId", "dbo.Accommodations");
            DropForeignKey("dbo.Bookings", "AccommodationId", "dbo.Accommodations");
            DropIndex("dbo.Images", new[] { "AccommodationId" });
            DropIndex("dbo.Bookings", new[] { "AccommodationId" });
            DropTable("dbo.Images");
            DropTable("dbo.Bookings");
            RenameIndex(table: "dbo.AccommodationFeatures", name: "IX_AmenityId", newName: "IX_FeatureId");
            RenameColumn(table: "dbo.AccommodationFeatures", name: "AmenityId", newName: "FeatureId");
            RenameTable(name: "dbo.Amenities", newName: "Features");
        }
    }
}
