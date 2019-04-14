namespace SmartCoziness.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ForeignKeyChanges : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Properties", "ImageId", "dbo.Images");
            DropForeignKey("dbo.Hosts", "PropertyId", "dbo.Properties");
            DropIndex("dbo.Hosts", new[] { "PropertyId" });
            DropIndex("dbo.Properties", new[] { "ImageId" });
            AddColumn("dbo.Properties", "HostId", c => c.Int(nullable: false));
            AddColumn("dbo.Images", "PropertyId", c => c.Int(nullable: false));
            CreateIndex("dbo.Images", "PropertyId");
            CreateIndex("dbo.Properties", "HostId");
            AddForeignKey("dbo.Properties", "HostId", "dbo.Hosts", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Images", "PropertyId", "dbo.Properties", "Id", cascadeDelete: true);
            DropColumn("dbo.Hosts", "PropertyId");
            DropColumn("dbo.Properties", "ImageId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Properties", "ImageId", c => c.Int(nullable: false));
            AddColumn("dbo.Hosts", "PropertyId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Images", "PropertyId", "dbo.Properties");
            DropForeignKey("dbo.Properties", "HostId", "dbo.Hosts");
            DropIndex("dbo.Properties", new[] { "HostId" });
            DropIndex("dbo.Images", new[] { "PropertyId" });
            DropColumn("dbo.Images", "PropertyId");
            DropColumn("dbo.Properties", "HostId");
            CreateIndex("dbo.Properties", "ImageId");
            CreateIndex("dbo.Hosts", "PropertyId");
            AddForeignKey("dbo.Hosts", "PropertyId", "dbo.Properties", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Properties", "ImageId", "dbo.Images", "Id", cascadeDelete: true);
        }
    }
}
