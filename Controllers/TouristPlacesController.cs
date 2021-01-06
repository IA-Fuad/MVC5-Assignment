using PracticeMVC.Helper;
using PracticeMVC.Models;
using System.Collections.Generic;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace PracticeMVC.Controllers
{
    public class TouristPlacesController : Controller
    {
        private ControllerHelper ch = new ControllerHelper();

        public ActionResult Index()
        {
            List<TouristPlaceViewModel> touristPlaces = ch.ShowData((List<TouristPlaceViewModel>)TempData["List"]);
            return View(touristPlaces);
        }

        [HttpGet]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TouristPlaceViewModel touristPlace = ch.ShowDetails(id.GetValueOrDefault());
            if (touristPlace == null)
            {
                return HttpNotFound();
            }
            return View(touristPlace);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TouristPlaceViewModel touristPlace, HttpPostedFileBase Image)
        {
            if (ModelState.IsValid)
            {
                if (ch.CheckIfNameExist(touristPlace.Name, ""))
                {
                    ModelState.AddModelError("Name", "Name already exist");
                    return View(touristPlace);
                }
                ch.SaveData(touristPlace, Image);
                return RedirectToAction("Index");
            }

            return View(touristPlace);
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TouristPlaceViewModel touristPlace = ch.FindData(id.GetValueOrDefault());
            if (touristPlace == null)
            {
                return HttpNotFound();
            }
            ViewBag.imgSrc = Url.Content(touristPlace.Image);
            return View(touristPlace);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TouristPlaceViewModel touristPlace, string CurrentName, HttpPostedFileBase ImageUpload)
        {
            if (ModelState.IsValid)
            {
                if (ch.CheckIfNameExist(touristPlace.Name, CurrentName))
                {
                    ModelState.AddModelError("Name", "Name already exist");
                    return View(touristPlace);
                }
                ch.EditData(touristPlace, ImageUpload);
                return RedirectToAction("Index");
            }
            return View(touristPlace);
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TouristPlaceViewModel touristPlace = ch.FindData(id.GetValueOrDefault());
            if (touristPlace == null)
            {
                return HttpNotFound();
            }
            return View(touristPlace);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ch.DeleteData(id);
            return RedirectToAction("Index");
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                ch.DisposeData();
            }
            base.Dispose(disposing);
        }


        [HttpGet]
        public ActionResult SortData(bool asc)
        {
            List<TouristPlaceViewModel> touristPlaces = ch.SortData(asc);
            TempData["List"] = touristPlaces;
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult SearchTouristPlace(string search)
        {
            List<TouristPlaceViewModel> touristPlaces = ch.SearchData(search);
            TempData["List"] = touristPlaces;
            return RedirectToAction("Index");
        }

    }
}
