using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RawMaterials.Models.Entities
{
    public class SubCategory
    {
        public long Id { get; set; }

        public Category Category { get; set; }

        public long CategoryId { get; set; }

        public string Name { get; set; }

        public List<Material> Materials { get; set; }

    }
}
