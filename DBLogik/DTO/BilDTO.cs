using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBLogik.DTO
{
    public class BilDTO
    {
        public Guid BilId { get; set; }

        public string Navn { get; set; }

        public string Mærke { get; set; }

        public string Model { get; set; }

        public int År { get; set; }

        public double IndKPris { get; set; }

        public double SalgsPris { get; set; }

        public Guid? BrugerId { get; set; }
    }

}
