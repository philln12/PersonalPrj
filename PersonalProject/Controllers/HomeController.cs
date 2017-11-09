using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PersonalProject.Controllers
{
    public class HomeController: Controller
    {
        // GET: Demo
        public ActionResult Index()
        {
            return View();
        }
    }
}