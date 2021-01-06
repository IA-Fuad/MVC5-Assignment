namespace PracticeMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeImageReq1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.TouristPlaces", "Image", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.TouristPlaces", "Image", c => c.String());
        }
    }
}
