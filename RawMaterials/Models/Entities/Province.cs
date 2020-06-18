using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RawMaterials.Models.Entities
{
    public class Province
    {
        public long Id { get; set; }

        public Country Country { get; set; }

        public long CountryId { get; set; }

        public List<City> Cities { get; set; }

        public string Name { get; set; }
    }
}
