namespace SmartCoziness.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedFeatureModel : DbMigration
    {
        public override void Up()
        {
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
        }
    }
}
