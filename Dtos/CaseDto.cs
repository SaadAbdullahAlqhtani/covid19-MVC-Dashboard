using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace covid19.Dtos
{
    public class CaseDto
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Type { get; set; }
        public string Deceased { get; set; }
        public string Description { get; set; }
    }
}
