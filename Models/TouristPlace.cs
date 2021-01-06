using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace PracticeMVC.Models
{
    public class TouristPlaceViewModel
    {
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Address { get; set; }

        [Required, Range(1, 5)]
        public double Rating { get; set; }

        [Required]
        public PlaceType Type { get; set; }

        [Required]
        public string Image { get; set; }
    }

    public class TouristPlaceEntityModel
    {
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Address { get; set; }

        [Required, Range(1, 5)]
        public double Rating { get; set; }

        [Required]
        public PlaceType Type { get; set; }

        [Required]
        public string Image { get; set; }
    }

    public class TouristPlaceDBContext: DbContext
    {
        public DbSet<TouristPlaceEntityModel> TouristPlacesEntityModel { get; set; }
    }

    public enum PlaceType
    {
        Beach,
        LandMark,
        Hills,
        Fountain
    }
}