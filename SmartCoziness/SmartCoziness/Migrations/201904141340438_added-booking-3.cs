namespace SmartCoziness.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedbooking3 : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Bookings", "AccommodationId");
            AddForeignKey("dbo.Bookings", "AccommodationId", "dbo.Accommodations", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Bookings", "AccommodationId", "dbo.Accommodations");
            DropIndex("dbo.Bookings", new[] { "AccommodationId" });
        }
    }
}
