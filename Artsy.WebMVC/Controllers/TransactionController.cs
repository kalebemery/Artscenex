using Artsy.Data;
using Artsy.Models.Transaction;
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
    public class TransactionController : Controller
    {

        // GET: Transaction
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new TransactionService(userId);
            var model = service.GetTransactions();

            return View(model);
        }


        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TransactionCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateTransactionService();

            if (service.CreateTransaction(model))
            {
                return RedirectToAction("Index");
            };

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateTransactionService();
            var model = svc.GetTransactionById(id);


            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateTransactionService();
            var model = svc.GetTransactionById(id);

            return View(model);
        }


        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteTransaction(int id)
        {
            var service = CreateTransactionService();

            service.DeleteTransaction(id);

            TempData["SaveResult"] = "Transaction deleted";

            return RedirectToAction("Index");
        }

        private TransactionService CreateTransactionService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new TransactionService(userId);
            return service;
        }

    }
}