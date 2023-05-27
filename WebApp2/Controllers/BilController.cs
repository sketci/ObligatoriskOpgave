using DBLogik;
using DBLogik.Model;
using System;
using System.Linq;
using System.Web.Mvc;

namespace WebApp2.Controllers
{
    public class BilController : Controller
    {
        private Database context = new Database();
        private BrugerBilViewModel vm = new BrugerBilViewModel();

        private static bool isSortedAscending = false;

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
        public ActionResult FindBilMærke(String mærke)
        {
            var filtreredeBiler = context.Biler.Where(b => b.Mærke.Contains(mærke)).ToList();
            vm.Biler = filtreredeBiler;
            //var vm = new BrugerBilViewModel { Biler = filtreredeBiler };
            return View("BilForside", vm);
        }

        [HttpGet]
        public ActionResult SorterÅr()
        {
            if (isSortedAscending)
            {
                vm.Biler = context.Biler.OrderByDescending(b => b.År).ToList();
                isSortedAscending = false;
            }
            else
            {
                vm.Biler = context.Biler.OrderBy(b => b.År).ToList();
                isSortedAscending = true;
            }
            return View("BilForside", vm);
        }
    }
}