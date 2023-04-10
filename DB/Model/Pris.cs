using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Model
{
    internal class Pris
    {

        public int prisId {  get; set; }
        public string navn { get; set; }
        public double beløb { get; set; }

        public bool indkøbsPris { get; set; }

        public bool salgsPris { get; set; }

        public Pris() {}

        public Pris(string navn, double beløb, bool indkøbsPris, bool salgsPris)
        {
            this.navn = navn;
            this.beløb = beløb;
            this.indkøbsPris = indkøbsPris;
            this.salgsPris = salgsPris;
        }

        public override string ToString()
        {
            return prisId + " " + navn + " " + beløb + " " + indkøbsPris + " " + salgsPris;
        }
    }
}
