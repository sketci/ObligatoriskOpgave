using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace DBLogik.Model
{
    public class Bil : INotifyDataErrorInfo
    {
        public Guid BilId { get; set; }

        [Display(Name = "Navn")]
        [Required(ErrorMessage = "Glemt navn")]
        [StringLength(70, MinimumLength = 2, ErrorMessage = "Skal være min. 2 chars")]
        public string Navn { get; set; }

        [Display(Name ="Mærke")]
        [Required(ErrorMessage = "Mærke er nødvendigt.")]
        [RegularExpression(@"^[a-zA-Z0-9\s]*$", ErrorMessage = "Bilmærket må kun indeholde bogstaver og tal.")]
        public string Mærke { get; set; }

        [Display(Name = "Model")]
        [Required(ErrorMessage = "Model er nødvendigt.")]
        [RegularExpression(@"^[a-zA-Z0-9\s]*$", ErrorMessage = "Bilmodellen må kun indeholde bogstaver og tal.")]
        public string Model { get; set; }

        [Display(Name = "År")]
        [Required(ErrorMessage = "År er nødvendigt.")]
        [Range(1886, 2099, ErrorMessage = "Året skal være mellem 1886 og 2099")]
        public int År { get; set; }

        [Display(Name = "Indkøbspris")]
        [Required(ErrorMessage = "Indkøbspris er nødvendig.")]
        [Range(0, Double.MaxValue, ErrorMessage = "Indkøbspris skal være et positivt tal.")]
        public double IndKPris { get; set; }

        [Display(Name = "Salgspris")]
        [Required(ErrorMessage = "Salgspris er nødvendig.")]
        [Range(0, Double.MaxValue, ErrorMessage = "Salgspris skal være et positivt tal.")]
        public double SalgsPris { get; set; }

        public Guid? BrugerId { get; set; }

        [ForeignKey("BrugerId")]
        public virtual Bruger Bruger { get; set; }

        private bool hasErrors = false;

        public bool HasErrors
        {
            get { return hasErrors; }
            set
            {
                if (hasErrors != value)
                {
                    hasErrors = value;
                    ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(null));
                }
            }
        }

        public IEnumerable GetErrors(string propertyName)
        {
            return new List<string>();
        }


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

        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        public string Validate()
        {
            var context = new ValidationContext(this, null, null);
            var results = new List<ValidationResult>();

            if (!Validator.TryValidateObject(this, context, results, true))
            {
                // Returner den første fejlmeddelelse, du støder på
                foreach (var result in results)
                {
                    if (result != ValidationResult.Success)
                    {
                        return result.ErrorMessage;
                    }
                }
            }

            return null;
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
