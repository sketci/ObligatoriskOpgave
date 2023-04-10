using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Model
{
    internal class Bil
    {
        private List<Pris> priser = new List<Pris> ();

        private List<Bruger> brugere = new List<Bruger> ();
        
        public string bilId { get; set; }
        public string navn { get; set; }

        public string mærke { get; set; }
        public string model { get; set; }
        public Bruger bruger { get; set; }
        public int år { get; set; }

        public virtual List<Pris> Priser { get { return priser; } }

        public virtual List<Bruger> Brugere { get { return brugere; } }
        public Bil() { }
        public Bil(string id, string navn, string mærke, string model, Bruger bruger, int år)
        {
            this.bilId = id;
            this.navn = navn;
            this.mærke = mærke;
            this.model = model;
            this.bruger = bruger;
            this.år = år;
        }

        public override string ToString()
        {
            return bilId + " " + navn + " " + mærke + " " + model + " " + bruger + " " + år;
        }
    }
}
