using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RawMaterials.Models.IO.RequestModels
{
    public class CategoryRequestModel
    {
        [Required]
        public string Name { get; set; }

        public long? SuperCategoryId { get; set; } = null;
    }
}
