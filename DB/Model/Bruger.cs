using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Model
{
    internal class Bruger
    {
        private List<Bil> biler = new List<Bil>();
        
        public int brugerId { get; set; }
        
        public string navn { get; set; }
        public string mail { get; set; }
        public Bil bil { get; set; }

        public bool medarbejder { get; set; }
        public virtual List<Bil> Biler { get { return biler; } }
        public Bruger() { }
        public Bruger(string navn, string mail, Bil bil) {
            this.navn = navn;
            this.mail = mail;
            this.bil = bil;
        }

        public override string ToString()
        {
            return navn + " " + mail + " " + bil + " " + medarbejder;
        }
    }
}
