using DatabaseLogik.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBLogik.Model
{
    public class BilPris
    {
        public Guid BilPrisId { get; set; }
        public Guid BilId { get; set; }
        public Guid PrisId { get; set; }

        public virtual Bil Bil { get; set; } // Navigation property
        public virtual ICollection<Pris> Priser { get; set; } // Navigation property for Pris entities

        public BilPris()
        {
            Priser = new HashSet<Pris>(); // Initialize the collection in the constructor
        }

        public BilPris(Guid bilId, Guid prisId)
        {
            BilPrisId = Guid.NewGuid();
            this.BilId = bilId;
            this.PrisId = prisId;
            Priser = new HashSet<Pris>(); // Initialize the collection in the constructor
        }
    }
}
