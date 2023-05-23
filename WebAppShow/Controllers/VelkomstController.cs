using DBLogik.Model;
using System.Collections.Generic;
using System.Web.Mvc;

namespace WebAppShow.Controllers
{
    public class VelkomstController : Controller
    {
        public ActionResult Index()
        {
           
            return View("Velkomst");
        }
    }
}