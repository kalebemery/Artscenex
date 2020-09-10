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
    public class PieceController : Controller
    {
        // GET: Piece
        //this shows all of the pieces for a current user
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new PieceService(userId);
            var model = service.GetPieces();

            return View(model);
        }

        //Making a request to get the create view
        //This section creates a GET method that gives users a View in which they can fill in the Title and Content for a new piece
        //will probably have to make changes to the artist and customer class as we do not want this to be allowed
        
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PieceCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreatePieceService();

            if (service.CreatePiece(model))
            {
                ViewBag.SaveResult = "Your Piece was created.";
                //only this has been added to piece
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Piece could not be created.");

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreatePieceService();
            var model = svc.GetPieceById(id);

            return View(model);
        }

        public ActionResult Details1(int id)
        {
            var svc = CreatePieceService();
            var model = svc.GetPiecesByArtist(id);
            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreatePieceService();
            var detail = service.GetPieceById(id);
            var model =
                new PieceEdit
                {
                    PieceId = detail.PieceId,
                    Name = detail.Name,
                    Desc = detail.Desc,
                    Price = detail.Price,
                    Stock = detail.Stock,
                    PieceType = detail.PieceType,
                    //do we need to add artist ID to this??
                    //why is piece id in edit in controller but not service ??
                };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, PieceEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.PieceId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreatePieceService();

            if (service.UpdatePiece(model))
            {
                TempData["SaveResult"] = "Your piece was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your piece could not be updated.");
            return View(model);
        }


        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreatePieceService();
            var model = svc.GetPieceById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePiece(int id)
        {
            var service = CreatePieceService();

            service.DeletePiece(id);

            TempData["SaveResult"] = "Your art was deleted";

            return RedirectToAction("Index");
        }

        private PieceService CreatePieceService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new PieceService(userId);
            return service;
        }


    }
}