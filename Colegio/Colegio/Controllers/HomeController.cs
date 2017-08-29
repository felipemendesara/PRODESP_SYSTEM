using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Colegio.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
         
            // View de informações
            return View();
        }

        public ActionResult Contact()
        {
     

            return View();
        }
    }
}