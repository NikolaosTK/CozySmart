namespace CozySmart.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedAppUserIdToStringInBookings : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Bookings", new[] { "ApplicationUser_Id" });
            DropColumn("dbo.Bookings", "ApplicationUserId");
            RenameColumn(table: "dbo.Bookings", name: "ApplicationUser_Id", newName: "ApplicationUserId");
            AlterColumn("dbo.Bookings", "ApplicationUserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Bookings", "ApplicationUserId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Bookings", new[] { "ApplicationUserId" });
            AlterColumn("dbo.Bookings", "ApplicationUserId", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Bookings", name: "ApplicationUserId", newName: "ApplicationUser_Id");
            AddColumn("dbo.Bookings", "ApplicationUserId", c => c.Int(nullable: false));
            CreateIndex("dbo.Bookings", "ApplicationUser_Id");
        }
    }
}
