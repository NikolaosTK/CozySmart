namespace CozySmart.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedAccommodationViewModels : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Types", newName: "Categories");
            RenameColumn(table: "dbo.Accommodations", name: "TypeId", newName: "CategoryId");
            RenameIndex(table: "dbo.Accommodations", name: "IX_TypeId", newName: "IX_CategoryId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Accommodations", name: "IX_CategoryId", newName: "IX_TypeId");
            RenameColumn(table: "dbo.Accommodations", name: "CategoryId", newName: "TypeId");
            RenameTable(name: "dbo.Categories", newName: "Types");
        }
    }
}
