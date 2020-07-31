using System.Collections.Generic;

namespace RawMaterials.Models.Entities
{
    public class Country
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public virtual List<Province> Provinces { get; set; }
    }
}
