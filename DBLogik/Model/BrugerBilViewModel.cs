using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DBLogik.Model
{
    public class BrugerBilViewModel
    {
        public List<Bruger> Brugere { get; set; }
        public List<Bil> Biler { get; set; }

        public Guid? SelectedBrugerId { get; set; }

        public Bruger BrugerDetaljer { get; set; }

        public SogBilViewModel SogeBil { get; set; }
    }
}