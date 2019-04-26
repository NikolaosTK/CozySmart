namespace CozySmart.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedAccommodationTypeEntity : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Types",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Accommodations", "TypeId", c => c.Int(nullable: false));
            CreateIndex("dbo.Accommodations", "TypeId");
            AddForeignKey("dbo.Accommodations", "TypeId", "dbo.Types", "Id", cascadeDelete: true);
            DropColumn("dbo.Accommodations", "Type");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Accommodations", "Type", c => c.String(nullable: false));
            DropForeignKey("dbo.Accommodations", "TypeId", "dbo.Types");
            DropIndex("dbo.Accommodations", new[] { "TypeId" });
            DropColumn("dbo.Accommodations", "TypeId");
            DropTable("dbo.Types");
        }
    }
}
