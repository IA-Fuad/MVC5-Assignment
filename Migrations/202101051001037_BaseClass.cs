namespace PracticeMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BaseClass : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.TouristPlaces", "Discriminator");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TouristPlaces", "Discriminator", c => c.String(nullable: false, maxLength: 128));
        }
    }
}
