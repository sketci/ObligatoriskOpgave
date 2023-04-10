using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilForhandler.Model
{
    public class Pris
    {
        public Guid PrisId { get; set; }
        public string Navn { get; set; }
        public double Beløb { get; set; }

        public bool IndkøbsPris { get; set; }

        public bool SalgsPris { get; set; }

        public Pris() { }

        public Pris(string navn, double beløb, bool indkøbsPris, bool salgsPris)
        {
            PrisId = Guid.NewGuid();
            this.Navn = navn;
            this.Beløb = beløb;
            this.IndkøbsPris = indkøbsPris;
            this.SalgsPris = salgsPris;
        }

        public override string ToString()
        {
            return PrisId + " " + Navn + " " + Beløb + " " + IndkøbsPris + " " + SalgsPris;
        }
    }
}
