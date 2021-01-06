namespace PracticeMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ImageFile : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TouristPlaces", "Image", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.TouristPlaces", "Image");
        }
    }
}
