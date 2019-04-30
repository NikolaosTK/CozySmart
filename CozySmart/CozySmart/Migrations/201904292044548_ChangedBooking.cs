namespace CozySmart.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedBooking : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Bookings", "Rating");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Bookings", "Rating", c => c.Int(nullable: false));
        }
    }
}
