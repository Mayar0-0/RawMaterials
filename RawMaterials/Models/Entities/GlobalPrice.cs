using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RawMaterials.Models.Entities
{
    public class GlobalPrice
    {
        public long Id { get; set; }

        public virtual Material Material { get; set; }

        public long MaterialId { get; set; }

        public double Price { get; set; }

        // public bool status { get; set; }
    }
}
