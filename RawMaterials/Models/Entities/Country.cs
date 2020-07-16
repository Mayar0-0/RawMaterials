using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RawMaterials.Models.Entities
{
    public class Country
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public virtual List<Province> Provinces { get; set; }
    }
}
