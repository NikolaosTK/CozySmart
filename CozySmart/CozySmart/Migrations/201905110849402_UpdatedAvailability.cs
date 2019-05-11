namespace CozySmart.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedAvailability : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Locations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Prefecture = c.String(),
                        City = c.String(),
                        AccommodationId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Accommodations", t => t.AccommodationId, cascadeDelete: true)
                .Index(t => t.AccommodationId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Locations", "AccommodationId", "dbo.Accommodations");
            DropIndex("dbo.Locations", new[] { "AccommodationId" });
            DropTable("dbo.Locations");
        }
    }
}
