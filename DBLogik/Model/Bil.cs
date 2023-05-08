using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DBLogik.Model
{
    public class Bil
    {
        public Guid BilId { get; set; }
        public string Navn { get; set; }
        public string Mærke { get; set; }
        public string Model { get; set; }
        public int År { get; set; }
        public double IndKPris { get; set; }
        public double SalgsPris { get; set; }

        public Guid? BrugerId { get; set; }

        [ForeignKey("BrugerId")]
        public virtual Bruger Bruger { get; set; }


        public Bil() { }

        public Bil(string navn, string mærke, string model, int år, double indKPris, double salgsPris)
        {
            BilId = Guid.NewGuid();
            this.Navn = navn;
            this.Mærke = mærke;
            this.Model = model;
            this.År = år;
            this.IndKPris = indKPris;
            this.SalgsPris = salgsPris;
        }


        public override string ToString()
        {
            return $"{Navn} {Model}";
        }

        public string ToStringWithAllAttributes()
        {
            return $"BilId: {BilId}, Navn: {Navn}, Mærke: {Mærke}, Model: {Model}, År: {År}, Indkøbspris: {IndKPris}, Salgspris: {SalgsPris}, BrugerId: {BrugerId}";
        }
    }
}
