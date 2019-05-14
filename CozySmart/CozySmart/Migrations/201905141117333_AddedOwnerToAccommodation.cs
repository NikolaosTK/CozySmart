namespace CozySmart.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedOwnerToAccommodation : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Accommodations", "ApplicationUserId", c => c.String(maxLength: 128));
            AlterColumn("dbo.Accommodations", "Description", c => c.String(maxLength: 1024));
            CreateIndex("dbo.Accommodations", "ApplicationUserId");
            AddForeignKey("dbo.Accommodations", "ApplicationUserId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Accommodations", "ApplicationUserId", "dbo.AspNetUsers");
            DropIndex("dbo.Accommodations", new[] { "ApplicationUserId" });
            AlterColumn("dbo.Accommodations", "Description", c => c.String(maxLength: 100));
            DropColumn("dbo.Accommodations", "ApplicationUserId");
        }
    }
}
