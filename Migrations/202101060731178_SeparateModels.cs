namespace PracticeMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeparateModels : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.TouristPlaces", newName: "TouristPlaceEntityModels");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.TouristPlaceEntityModels", newName: "TouristPlaces");
        }
    }
}
