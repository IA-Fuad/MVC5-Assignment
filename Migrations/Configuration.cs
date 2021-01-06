namespace PracticeMVC.Migrations
{
    using System.Data.Entity.Migrations;
    using PracticeMVC.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<PracticeMVC.Models.TouristPlaceDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "PracticeMVC.Models.TouristPlaceDBContext";
        }

        protected override void Seed(PracticeMVC.Models.TouristPlaceDBContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            context.TouristPlacesEntityModel.AddOrUpdate(i => i.Name,
                new TouristPlaceEntityModel
                {
                    Name = "Moynamoti",
                    Address = "Comilla",
                    Rating = 3.5,
                    Type = PlaceType.LandMark,
                    Image = "~/ImageFiles/glass.png"
                },
                new TouristPlaceEntityModel
                {
                    Name = "CoxBazar",
                    Address = "Chittagong",
                    Rating = 4.5,
                    Type = PlaceType.Beach,
                    Image = "~/ImageFiles/glass.png"
                },
                new TouristPlaceEntityModel
                {
                    Name = "Jaflong",
                    Address = "Sylhet",
                    Rating = 3.0,
                    Type = PlaceType.LandMark,
                    Image = "~/ImageFiles/glass.png"
                }
            );
        }
    }
}
