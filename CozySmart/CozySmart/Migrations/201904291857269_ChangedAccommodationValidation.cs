namespace CozySmart.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedAccommodationValidation : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Accommodations", "Adress", c => c.String(maxLength: 100));
            AlterColumn("dbo.Accommodations", "Occupancy", c => c.Byte(nullable: false));
            AlterColumn("dbo.Accommodations", "Bedrooms", c => c.Int());
            AlterColumn("dbo.Accommodations", "Baths", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Accommodations", "Baths", c => c.Int(nullable: false));
            AlterColumn("dbo.Accommodations", "Bedrooms", c => c.Int(nullable: false));
            AlterColumn("dbo.Accommodations", "Occupancy", c => c.Int(nullable: false));
            AlterColumn("dbo.Accommodations", "Adress", c => c.String(nullable: false));
        }
    }
}
