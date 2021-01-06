namespace PracticeMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class VirtualImage : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TouristPlaces", "Discriminator", c => c.String(nullable: false, maxLength: 128));
        }
        
        public override void Down()
        {
            DropColumn("dbo.TouristPlaces", "Discriminator");
        }
    }
}
