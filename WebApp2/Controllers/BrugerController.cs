using DBLogik;
using DBLogik.Model;
using System;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace WebApp2.Controllers
{
    public class BrugerController : Controller
    {
        private Database context = new Database();
        private BrugerBilViewModel vm = new BrugerBilViewModel();
       

        public ActionResult BrugerForside(Guid? SelectedBrugerId)
        {
            HentAlleBrugere();
            if (SelectedBrugerId.HasValue)
            {
                vm.SelectedBrugerId = SelectedBrugerId.Value;
            }
            return View("BrugerForside", vm);
        }

        public void HentAlleBrugere()
        {
           
            var alleBrugere = context.Bruger.ToList();
            vm.Brugere = alleBrugere;
        }


        public ActionResult BrugerDetails(Guid? id)
        {
            var bruger = context.Bruger.FirstOrDefault(b => b.BrugerId == id);
            if (bruger == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }
            return PartialView("_Details", bruger);
        }
    }
}