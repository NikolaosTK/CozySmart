namespace CozySmart.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class JoinedUsersWithBookings : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Bookings", "ApplicationUserId", c => c.Int(nullable: false));
            AddColumn("dbo.Bookings", "ApplicationUser_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.AspNetUsers", "DateJoined", c => c.DateTime(nullable: false));
            CreateIndex("dbo.Bookings", "ApplicationUser_Id");
            AddForeignKey("dbo.Bookings", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Bookings", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Bookings", new[] { "ApplicationUser_Id" });
            DropColumn("dbo.AspNetUsers", "DateJoined");
            DropColumn("dbo.Bookings", "ApplicationUser_Id");
            DropColumn("dbo.Bookings", "ApplicationUserId");
        }
    }
}
