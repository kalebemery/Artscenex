using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Artsy.WebMVC.Controllers
{
    public class PieceController : Controller
    {
        // GET: Piece
        public ActionResult Index()
        {
            return View();
        }
    }
}