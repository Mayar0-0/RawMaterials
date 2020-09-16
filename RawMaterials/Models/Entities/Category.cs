using System.Collections.Generic;

namespace RawMaterials.Models.Entities
{
    public class Category
    {

        public long Id { get; set; }

        public string Name { get; set; }

        public virtual Category SuperCategory { get; set; }

        public long? SuperCategoryId { get; set; }

        public virtual List<Category> SubCategories { get; set; }

        public virtual List<Material> Materials { get; set; }


    }
}
