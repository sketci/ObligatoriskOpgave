using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilForhandler.Model
{
    public class Bruger
    {
      
        public Guid BrugerId { get; set; }

        public string Navn { get; set; }
        public string Mail { get; set; }
        
        public bool Medarbejder { get; set; }
        public virtual ICollection<Bil> Biler { get; set; } //navigationsegenksab
        public Bruger() { }
        public Bruger(string navn, string mail)
        {
            BrugerId = Guid.NewGuid();
            this.Navn = navn;
            this.Mail = mail;
          
        }

        public override string ToString()
        {
            return Navn + " " + Mail + " " + Medarbejder;
        }
    }
}
