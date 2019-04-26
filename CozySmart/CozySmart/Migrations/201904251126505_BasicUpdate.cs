namespace CozySmart.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BasicUpdate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accommodations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 32),
                        Adress = c.String(nullable: false),
                        Description = c.String(maxLength: 100),
                        Type = c.String(nullable: false),
                        Occupancy = c.Int(nullable: false),
                        Rooms = c.Int(nullable: false),
                        Baths = c.Int(nullable: false),
                        Price = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Features",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AccommodationFeatures",
                c => new
                    {
                        AccommodationId = c.Int(nullable: false),
                        FeatureId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.AccommodationId, t.FeatureId })
                .ForeignKey("dbo.Accommodations", t => t.AccommodationId, cascadeDelete: true)
                .ForeignKey("dbo.Features", t => t.FeatureId, cascadeDelete: true)
                .Index(t => t.AccommodationId)
                .Index(t => t.FeatureId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AccommodationFeatures", "FeatureId", "dbo.Features");
            DropForeignKey("dbo.AccommodationFeatures", "AccommodationId", "dbo.Accommodations");
            DropIndex("dbo.AccommodationFeatures", new[] { "FeatureId" });
            DropIndex("dbo.AccommodationFeatures", new[] { "AccommodationId" });
            DropTable("dbo.AccommodationFeatures");
            DropTable("dbo.Features");
            DropTable("dbo.Accommodations");
        }
    }
}
