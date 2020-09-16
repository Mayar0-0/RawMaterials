using System.Collections.Generic;

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
