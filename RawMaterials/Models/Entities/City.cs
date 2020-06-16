using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;

namespace RawMaterials.Models.Entities
{
    public class City
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public Province Province { get; set; }

        public int ProvinceId { get; set; }


    }
}
