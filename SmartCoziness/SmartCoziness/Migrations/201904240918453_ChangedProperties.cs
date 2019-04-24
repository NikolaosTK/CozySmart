namespace SmartCoziness.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedProperties : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Accommodations", "Occupancy", c => c.Int(nullable: false));
            AddColumn("dbo.Accommodations", "Price", c => c.Int(nullable: false));
            AddColumn("dbo.Accommodations", "Availability_StartAvailability", c => c.DateTime(nullable: false));
            AddColumn("dbo.Accommodations", "Availability_EndAvailability", c => c.DateTime(nullable: false));
            AddColumn("dbo.Accommodations", "AvailabilityId", c => c.Int(nullable: false));
            AddColumn("dbo.Bookings", "Occupancy", c => c.Int(nullable: false));
            DropColumn("dbo.Accommodations", "Availability");
            DropColumn("dbo.Bookings", "NumberOfTenants");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Bookings", "NumberOfTenants", c => c.Int(nullable: false));
            AddColumn("dbo.Accommodations", "Availability", c => c.Int(nullable: false));
            DropColumn("dbo.Bookings", "Occupancy");
            DropColumn("dbo.Accommodations", "AvailabilityId");
            DropColumn("dbo.Accommodations", "Availability_EndAvailability");
            DropColumn("dbo.Accommodations", "Availability_StartAvailability");
            DropColumn("dbo.Accommodations", "Price");
            DropColumn("dbo.Accommodations", "Occupancy");
        }
    }
}
