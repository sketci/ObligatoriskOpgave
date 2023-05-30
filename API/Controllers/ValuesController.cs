using DBLogik;
using DBLogik.DTO;
using DBLogik.Mappers;
using DBLogik.Model;
using Microsoft.Ajax.Utilities;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace API.Controllers
{
    public class ValuesController : ApiController
    {
        
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet]
        public BrugerDTO Get(string mail)
        {
            using (var context = new Database())
            {
                var bruger = context.Bruger.Include("Biler").FirstOrDefault(b => b.Mail == mail);
                var brugerDTO = Mappers.MapToDTO(bruger);
                return brugerDTO;
            }
        }


        // POST api/values
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
