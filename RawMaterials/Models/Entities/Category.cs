using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RawMaterials.Models.Entities
{
    public class Category
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public List<SubCategory> SubCategories { get; set; }

    }
}
