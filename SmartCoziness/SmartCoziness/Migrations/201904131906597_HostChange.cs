namespace SmartCoziness.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class HostChange : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Hosts", "PhoneNumber", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Hosts", "PhoneNumber", c => c.Int(nullable: false));
        }
    }
}
