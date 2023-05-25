using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DBLogik;
using DBLogik.Model;

namespace WebApp2.Controllers
{
    public class BilController : Controller
    {
        private Database context = new Database();
        // GET: Bil
        [HttpGet]
        public ActionResult BilForside()
        {
            BrugerBilViewModel vm = new BrugerBilViewModel();

            using (context)
            {
                
                var alleBiler = context.Biler.ToList();
                //vm.Biler.AddRange(alleBiler);
                vm.Biler = alleBiler;

                var databaseName = context.Database.Connection.Database;
                System.Diagnostics.Debug.WriteLine(databaseName);

                //evt sæt return andet sted
                return View("BilForside", vm);
            }
        }
    }
}   