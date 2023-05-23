using DBLogik.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebAppShow.Controllers
{
    public class BrugerController : Controller
    {
        // GET: Bruger

        public ActionResult Index()
        {
            List<Bruger> brugere;


            return View("BrugerForside");
        }
    }
}