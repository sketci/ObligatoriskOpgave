using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBLogik.DTO
{
    public class RandomUserDTO
    {

        public class Name
        {
            public string first { get; set; }
            public string last { get; set; }
        }

        public class Result
        {
            public string gender { get; set; }
            public Name name { get; set; }
            public string email { get; set; }
        }

        public class Root
        {
            public List<Result> results { get; set; }
        }

    }
}
