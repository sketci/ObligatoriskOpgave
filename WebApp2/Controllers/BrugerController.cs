using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApp2.Controllers
{
    public class BrugerController : Controller
    {
        // GET: Bruger
        public ActionResult BrugerForside()
        {
            return View();
        }
    }
}