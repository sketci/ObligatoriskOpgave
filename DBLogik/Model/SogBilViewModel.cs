using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DBLogik.Model
{
    public class SogBilViewModel
    {
        [Display(Name = "Mærke")]
        [Required(ErrorMessage = "Mærke er nødvendigt.")]
        [RegularExpression(@"^[a-zA-Z0-9\s]*$", ErrorMessage = "Bilmærket må kun indeholde bogstaver og tal.")]
        public string Mærke { get; set; }
    }
}
