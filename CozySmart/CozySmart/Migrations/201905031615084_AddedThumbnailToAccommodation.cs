namespace CozySmart.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedThumbnailToAccommodation : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Accommodations", "Thumbnail", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Accommodations", "Thumbnail");
        }
    }
}
