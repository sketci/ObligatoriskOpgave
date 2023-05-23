using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DBLogik.Model;

namespace WebAppShow.Models
{
    public class BrugerBilViewModel
    {
        public List<Bruger> Brugere { get; set; }
        public List<Bil> Biler { get; set; }
    }
}