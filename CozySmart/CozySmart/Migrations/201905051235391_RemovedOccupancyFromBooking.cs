namespace CozySmart.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedOccupancyFromBooking : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Bookings", "Occupancy");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Bookings", "Occupancy", c => c.Int(nullable: false));
        }
    }
}
