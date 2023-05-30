using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBLogik.DTO
{
    public class BrugerDTO
    {
        public Guid BrugerId { get; set; }

        public string Navn { get; set; }

        public string Mail { get; set; }

        public string Køn { get; set; }

        public bool HarBørn { get; set; }

        public ICollection<String> BilerID { get; set; }
    }
}
