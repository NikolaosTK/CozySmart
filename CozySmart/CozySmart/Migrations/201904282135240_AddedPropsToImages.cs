namespace CozySmart.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedPropsToImages : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Images", "Title", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Images", "Title");
        }
    }
}
