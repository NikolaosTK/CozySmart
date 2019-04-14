namespace SmartCoziness.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedPropertyToAccommodation : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Properties", newName: "Accommodations");
            RenameColumn(table: "dbo.Images", name: "PropertyId", newName: "AccommodationId");
            RenameIndex(table: "dbo.Images", name: "IX_PropertyId", newName: "IX_AccommodationId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Images", name: "IX_AccommodationId", newName: "IX_PropertyId");
            RenameColumn(table: "dbo.Images", name: "AccommodationId", newName: "PropertyId");
            RenameTable(name: "dbo.Accommodations", newName: "Properties");
        }
    }
}
