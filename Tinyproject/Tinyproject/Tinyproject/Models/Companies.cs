using System;
using System.Collections.Generic;
using System.Text;

namespace Tinyproject.Models
{
    public class Companies
    {
        public Guid CompanyId { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
