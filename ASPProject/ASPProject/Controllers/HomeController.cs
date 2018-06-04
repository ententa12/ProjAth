using ASPProject.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASPProject.Controllers
{
    public class HomeController : Controller
    {
        DatabaseLogic _db;
        public HomeController()
        {
            _db = new DatabaseLogic();
        }
        //[Authorize(Roles = "Secretary")]
        public ActionResult Index()
        {
            return View();
        }
        [Authorize(Roles = "Admin,Editor")]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        [Authorize(Roles = "Secretary")]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}