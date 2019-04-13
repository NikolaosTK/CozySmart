namespace SmartCoziness.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Booking : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bookings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Start = c.DateTime(nullable: false),
                        End = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Hosts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        PhoneNumber = c.Int(nullable: false),
                        Email = c.String(nullable: false),
                        Adress = c.String(),
                        DateJoined = c.DateTime(nullable: false),
                        PropertyId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Properties", t => t.PropertyId, cascadeDelete: true)
                .Index(t => t.PropertyId);
            
            CreateTable(
                "dbo.Properties",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Owner = c.String(nullable: false),
                        Title = c.String(nullable: false, maxLength: 32),
                        Type = c.String(nullable: false),
                        Description = c.String(maxLength: 100),
                        Rooms = c.Int(nullable: false),
                        Baths = c.Int(nullable: false),
                        Adress = c.String(nullable: false),
                        Rating = c.Int(nullable: false),
                        Availability = c.Int(nullable: false),
                        ImageId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Images", t => t.ImageId, cascadeDelete: true)
                .Index(t => t.ImageId);
            
            CreateTable(
                "dbo.Images",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ImageUrl = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tenants",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        DateJoined = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Hosts", "PropertyId", "dbo.Properties");
            DropForeignKey("dbo.Properties", "ImageId", "dbo.Images");
            DropIndex("dbo.Properties", new[] { "ImageId" });
            DropIndex("dbo.Hosts", new[] { "PropertyId" });
            DropTable("dbo.Tenants");
            DropTable("dbo.Images");
            DropTable("dbo.Properties");
            DropTable("dbo.Hosts");
            DropTable("dbo.Bookings");
        }
    }
}
