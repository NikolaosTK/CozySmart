namespace SmartCoziness.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedbookinginitial : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Bookings", "AccommodationId", c => c.Int(nullable: false));
            AddColumn("dbo.Bookings", "Rating", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Bookings", "Rating");
            DropColumn("dbo.Bookings", "AccommodationId");
        }
    }
}
