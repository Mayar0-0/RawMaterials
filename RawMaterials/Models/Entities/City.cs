using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;

namespace RawMaterials.Models.Entities
{
    public class City
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public virtual Province Province { get; set; }

        public long ProvinceId { get; set; }
     

    }
}
