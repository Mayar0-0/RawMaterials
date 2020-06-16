using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RawMaterials.Models.Entities
{
    public class SuplierCategory
    {
        public long Id { get; set; }

        public Category Category { get; set; }

        public long CategoryId { get; set; }

        public Suplier Suplier { get; set; }

        public int SuplierId { get; set; }
    }
}
