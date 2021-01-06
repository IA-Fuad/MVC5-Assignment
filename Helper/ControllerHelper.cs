using PracticeMVC.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Hosting;


namespace PracticeMVC.Helper
{
    public class ControllerHelper
    {
        private TouristPlaceDBContext db = new TouristPlaceDBContext();

        private TouristPlaceViewModel ConvertEnityToViewModel(TouristPlaceEntityModel touristPlaceEntityModel)
        {
            TouristPlaceViewModel touristPlaceViewModel = new TouristPlaceViewModel()
            {
                ID = touristPlaceEntityModel.ID,
                Name = touristPlaceEntityModel.Name,
                Address = touristPlaceEntityModel.Address,
                Rating = touristPlaceEntityModel.Rating,
                Type = touristPlaceEntityModel.Type,
                Image = touristPlaceEntityModel.Image
            };
            return touristPlaceViewModel;
        }

        private TouristPlaceEntityModel ConvertViewToEntityModel(TouristPlaceViewModel touristPlaceViewModel)
        {
            
            TouristPlaceEntityModel touristPlaceEntityModel = new TouristPlaceEntityModel()
            {
                ID = touristPlaceViewModel.ID,
                Name = touristPlaceViewModel.Name,
                Address = touristPlaceViewModel.Address,
                Rating = touristPlaceViewModel.Rating,
                Type = touristPlaceViewModel.Type,
                Image = touristPlaceViewModel.Image
            };
            return touristPlaceEntityModel;
        }

        public List<TouristPlaceViewModel> ShowData(List<TouristPlaceViewModel> touristPlaces)
        {
            if (touristPlaces == null)
            {
                touristPlaces = new List<TouristPlaceViewModel>();
                List<TouristPlaceEntityModel> touristPlaceEntityModels = db.TouristPlacesEntityModel.ToList();
                foreach (TouristPlaceEntityModel touristPlaceEntityModel in touristPlaceEntityModels)
                {
                    touristPlaces.Add(ConvertEnityToViewModel(touristPlaceEntityModel));
                }
            }
            return touristPlaces;
        }

        public void SaveData(TouristPlaceViewModel touristPlace, HttpPostedFileBase Image)
        {
            if (Image != null)
            {
                string path = HostingEnvironment.MapPath("~/ImageFiles/" + Image.FileName);
                Image.SaveAs(path);
                touristPlace.Image = "~/ImageFiles/" + Image.FileName;
            }
            else
            {
                return;
            }

            db.TouristPlacesEntityModel.Add(ConvertViewToEntityModel(touristPlace));
            db.SaveChanges();
        }

        public void DeleteData(int id)
        {
            TouristPlaceEntityModel touristPlace = db.TouristPlacesEntityModel.Find(id);
            db.TouristPlacesEntityModel.Remove(touristPlace);
            db.SaveChanges();
        }

        public TouristPlaceViewModel FindData(int id)
        {
            TouristPlaceViewModel touristPlace = ConvertEnityToViewModel(db.TouristPlacesEntityModel.Find(id));
            return touristPlace;
        }

        public TouristPlaceViewModel ShowDetails(int id)
        {
            TouristPlaceViewModel touristPlace = ConvertEnityToViewModel(db.TouristPlacesEntityModel.Find(id));
            return touristPlace;
        }

        public void EditData(TouristPlaceViewModel touristPlace, HttpPostedFileBase ImageUpload)
        {
            if (ImageUpload != null)
            {
                string path = HostingEnvironment.MapPath("~/ImageFiles/" + ImageUpload.FileName);
                ImageUpload.SaveAs(path);
                touristPlace.Image = "~/ImageFiles/" + ImageUpload.FileName;
            }

            TouristPlaceEntityModel touristPlaceEntityModel = ConvertViewToEntityModel(touristPlace);
            db.Entry(touristPlaceEntityModel).State = EntityState.Modified;
            db.SaveChanges();
        }

        public bool CheckIfNameExist(string Name, string CurrentName)
        {
            if (Name == CurrentName)
            {
                return false;
            }
            TouristPlaceEntityModel touristPlaceEntity = db.TouristPlacesEntityModel.AsNoTracking().FirstOrDefault(tp => tp.Name.Equals(Name));
            if (touristPlaceEntity == null)
            {
                return false;
            }
            return true;
        }

        public List<TouristPlaceViewModel> SearchData(string search)
        {
            List<TouristPlaceEntityModel> touristPlacesEntity = db.TouristPlacesEntityModel.Where(tp => tp.Name.Contains(search)).ToList();
            List<TouristPlaceViewModel> touristPlaces = new List<TouristPlaceViewModel>();
            foreach (TouristPlaceEntityModel touristPlaceEntityModel in touristPlacesEntity)
            {
                touristPlaces.Add(ConvertEnityToViewModel(touristPlaceEntityModel));
            }
            return touristPlaces;
        }

        public List<TouristPlaceViewModel> SortData(bool asc)
        {
            List<TouristPlaceEntityModel> touristPlacesEntity = db.TouristPlacesEntityModel.ToList();
            if (asc)
            {
                touristPlacesEntity = touristPlacesEntity.OrderBy(t => t.Name).ToList();
            }
            else
            {
                touristPlacesEntity = touristPlacesEntity.OrderByDescending(t => t.Name).ToList();
            }

            List<TouristPlaceViewModel> touristPlaces = new List<TouristPlaceViewModel>();
            foreach (TouristPlaceEntityModel touristPlaceEntityModel in touristPlacesEntity)
            {
                touristPlaces.Add(ConvertEnityToViewModel(touristPlaceEntityModel));
            }

            return touristPlaces;
        }

        public void DisposeData()
        {
            db.Dispose();
        }
    }


}