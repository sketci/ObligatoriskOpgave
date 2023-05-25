using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApp2.Controllers
{
    public class VelkomstController : Controller
    {
        // GET: Velkomst
        public ActionResult Velkomstside()
        {
            return View();
        }

        public ActionResult layouttest()
        {
            return View();
        }
    }
}