using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace DBLogik.Model
{
    public class Bruger : INotifyDataErrorInfo
    {
        public Guid BrugerId { get; set; }

        [Display(Name = "Indsæt navn")]
        [Required(ErrorMessage = "Glemt navn")]
        [StringLength(70, MinimumLength =2, ErrorMessage ="Skal være min. 2 chars")]
        public string Navn { get; set; }

        [Display(Name ="Indsæt mail")]
        [RegularExpression (@"\S+@(\S+\.)+\w{2,4}",
        ErrorMessage = "There is a problem with the email")]
        [Required(ErrorMessage = "You must enter email")]
        public string Mail { get; set; }

        [Display(Name = "Vælg Køn")]
        [RegularExpression("(Mand|Kvinde|Andet)", ErrorMessage = "Vælg venligst et køn.")]
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

        public string ToDetailedString()
        {
            return $"Navn: {Navn}, Mail: {Mail}, Køn: {Køn}, HarBørn: {HarBørn}";
        }

        private Dictionary<string, List<string>> _errors = new Dictionary<string, List<string>>();

        public bool HasErrors
        {
            get { return _errors.Any(); }
        }

        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        public IEnumerable GetErrors(string propertyName)
        {
            if (_errors.ContainsKey(propertyName))
                return _errors[propertyName];
            return null;
        }

        protected virtual void OnErrorsChanged(string propertyName)
        {
            ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
        }
    }
}
