using DBLogik.DTO;
using DBLogik.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBLogik.Mappers
{
    public static class Mappers
    {
        public static BilDTO MapToDTO(this Bil bil)
        {
            return new BilDTO
            {
                BilId = bil.BilId,
                Navn = bil.Navn,
                Mærke = bil.Mærke,
                Model = bil.Model,
                År = bil.År,
                IndKPris = bil.IndKPris,
                SalgsPris = bil.SalgsPris,
                BrugerId = bil.BrugerId
            };
        }

        public static BrugerDTO MapToDTO(this Bruger bruger)
        {
            var brugerDTO = new BrugerDTO
            {
                BrugerId = bruger.BrugerId,
                Navn = bruger.Navn,
                Mail = bruger.Mail,
                Køn = bruger.Køn,
                HarBørn = bruger.HarBørn,
                BilerID = bruger.Biler?.Select(b => b.BilId.ToString()).ToList()
            };

            return brugerDTO;
        }
    }

}
