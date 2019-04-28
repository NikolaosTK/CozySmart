namespace CozySmart.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedtoProperties : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Accommodations", "Bedrooms", c => c.Int(nullable: false));
            DropColumn("dbo.Accommodations", "Rooms");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Accommodations", "Rooms", c => c.Int(nullable: false));
            DropColumn("dbo.Accommodations", "Bedrooms");
        }
    }
}
