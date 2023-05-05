using System;
using System.Collections.Generic;

namespace DBLogik.Model
{
    public class Bruger
    {
        public Guid BrugerId { get; set; }
        public string Navn { get; set; }
        public string Mail { get; set; }
        public string Køn { get; set; }
        public bool HarBørn { get; set; }
        public virtual ICollection<Bil> Biler { get; set; } // Navigation property
        
        public Bruger() { }

        public Bruger(string navn, string mail, string køn, bool harBørn)
        {
            BrugerId = Guid.NewGuid();
            this.Navn = navn;
            this.Mail = mail;
            this.Køn = køn;
            this.HarBørn = harBørn;
        }

        public override string ToString()
        {
            return Navn + " " + Mail;
        }
    }
}
