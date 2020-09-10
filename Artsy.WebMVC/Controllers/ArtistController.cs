using Artsy.Data;
using Artsy.Models;
using Artsy.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Artsy.WebMVC.Controllers
{
    [Authorize]
    public class ArtistController : Controller
    {
        // GET: Artist  //need to do this by Artist Type
        //apparently shows all of the artists for a specific user
        //need to change this 
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ArtistService(userId);
            var model = service.GetArtists();

            return View(model);
        }
        //Making a request to get the create view
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ArtistCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateArtistService();

            if (service.CreateArtist(model))
            {
                return RedirectToAction("Index");
            };

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateArtistService();
            var model = svc.GetArtistById(id);
           

           
            return View(model);
        }

        public ActionResult Details2(ArtistType? type)
        {
            var svc = CreateArtistService();
            var model = svc.GetArtistByEnum(type);

            return View(model);
        }
        public ActionResult List(ArtistType? type)
        {
            var svc = CreateArtistService();
            var model = svc.GetArtistByEnum(type);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateArtistService();
            var detail = service.GetArtistById(id);
            var model =
                new ArtistEdit
                {
                    ArtistId = detail.ArtistId,
                    FullName = detail.FullName,
                    ArtistBio = detail.ArtistBio,
                    ArtistType = detail.ArtistType,
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ArtistEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.ArtistId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateArtistService();

            if (service.UpdateArtist(model))
            {
                TempData["SaveResult"] = "Your profile was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your profile could not be updated.");
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateArtistService();
            var model = svc.GetArtistById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteArtist(int id)
        {
            var service = CreateArtistService();

            service.DeleteArtist(id);

            TempData["SaveResult"] = "Your profile was deleted";

            return RedirectToAction("Index");
        }


        private ArtistService CreateArtistService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ArtistService(userId);
            return service;
        }

       
    }
}