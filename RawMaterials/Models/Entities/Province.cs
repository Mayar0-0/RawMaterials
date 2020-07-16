using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RawMaterials.Models.Entities
{
    public class Province
    {
        public long Id { get; set; }

        public virtual Country Country { get; set; }

        public long CountryId { get; set; }

        public virtual List<City> Cities { get; set; }

        public string Name { get; set; }
    }
}
