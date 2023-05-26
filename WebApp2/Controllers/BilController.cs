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
        private BrugerBilViewModel vm = new BrugerBilViewModel();

        [HttpGet]
        public ActionResult BilForside()
        {
            using (context)
            {
                HentAlleBiler();
                
                return View("BilForside", vm);
            }
        }

        public void HentAlleBiler()
        {
            var alleBiler = context.Biler.ToList();
            vm.Biler = alleBiler;
        }

        public Bil HentBil(Guid guid)
        {
            var bil = context.Biler.FirstOrDefault(m => m.BilId == guid);
            return bil;
        }
        [HttpPost]
        public ActionResult FindBilNavn(String navn)
        {
            var filtreredeBiler = context.Biler.Where(b => b.Navn.Contains(navn)).ToList();
            vm.Biler = filtreredeBiler;
            //var vm = new BrugerBilViewModel { Biler = filtreredeBiler };
            return View("BilForside", vm);
        }
    }
}