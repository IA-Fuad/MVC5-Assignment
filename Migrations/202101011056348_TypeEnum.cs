namespace PracticeMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TypeEnum : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.TouristPlaces", "Type", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.TouristPlaces", "Type", c => c.String(nullable: false));
        }
    }
}
