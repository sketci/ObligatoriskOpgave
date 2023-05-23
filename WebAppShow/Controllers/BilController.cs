using DBLogik;
using DBLogik.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebAppShow.Controllers
{
    public class BilController : Controller
    {
        // GET: Bil
        public ActionResult Index()
        {
            List<Bil> biler;

            using (var context = new Database())

            return View();
        }
    }
}