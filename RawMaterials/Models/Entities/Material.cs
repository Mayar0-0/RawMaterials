using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RawMaterials.Models.Entities
{
    public class Material
    {
        public long Id { get; set; }

        public SubCategory SubCategory { get; set; }

        public long SubCategoryId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }




    }
}
