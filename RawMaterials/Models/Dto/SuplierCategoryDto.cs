using RawMaterials.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RawMaterials.Models.Dto
{
    public class SuplierCategoryDto
    {
        public long Id { get; set; }
        public virtual Category Category { get; set; }

        public long CategoryId { get; set; }

        public virtual Suplier Suplier { get; set; }

        public string SuplierId { get; set; }
    }


}
