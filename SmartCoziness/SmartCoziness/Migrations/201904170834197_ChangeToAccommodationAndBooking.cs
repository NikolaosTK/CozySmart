namespace SmartCoziness.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeToAccommodationAndBooking : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Bookings", "Arrival", c => c.DateTime(nullable: false));
            AddColumn("dbo.Bookings", "Departure", c => c.DateTime(nullable: false));
            AddColumn("dbo.Bookings", "NumberOfTenants", c => c.Int(nullable: false));
            DropColumn("dbo.Accommodations", "Owner");
            DropColumn("dbo.Bookings", "Start");
            DropColumn("dbo.Bookings", "End");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Bookings", "End", c => c.DateTime(nullable: false));
            AddColumn("dbo.Bookings", "Start", c => c.DateTime(nullable: false));
            AddColumn("dbo.Accommodations", "Owner", c => c.String(nullable: false));
            DropColumn("dbo.Bookings", "NumberOfTenants");
            DropColumn("dbo.Bookings", "Departure");
            DropColumn("dbo.Bookings", "Arrival");
        }
    }
}
