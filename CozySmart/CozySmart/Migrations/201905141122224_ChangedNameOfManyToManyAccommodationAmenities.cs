namespace CozySmart.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedNameOfManyToManyAccommodationAmenities : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.AccommodationFeatures", newName: "AccommodationAmenities");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.AccommodationAmenities", newName: "AccommodationFeatures");
        }
    }
}
