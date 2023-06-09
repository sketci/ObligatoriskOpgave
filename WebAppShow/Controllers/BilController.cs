﻿using DBLogik;
using DBLogik.Model;
using System.Linq;
using System.Web.Mvc;

namespace WebAppShow.Controllers
{
    public class BilController : Controller
    {

        [HttpGet]
        public ActionResult BilForside()
        {
            BrugerBilViewModel vm = new BrugerBilViewModel();


            using (var context = new Database())
            {
                //var context = new Database();


                //Bil b = new Bil("VirkNu", "test", "test", 2039, 100.00, 200.00);
                //context.Biler.Add(b);
                //context.SaveChanges();

                //var bil = context.Biler.ToList();
                
                var alleBiler = context.Biler.ToList();

                vm.Biler = alleBiler;

                //vm.Biler = context.Biler.ToList();

                //vm.Biler[0] = context.Biler.FirstOrDefault();

                ViewBag.Count = vm.Biler.Count;

                var databaseName = context.Database.Connection.Database;
                System.Diagnostics.Debug.WriteLine(databaseName);

                return View("BilForside", vm);
            }
        }
    }
}