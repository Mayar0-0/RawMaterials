using System.ComponentModel.DataAnnotations;

namespace RawMaterials.Models.IO.RequestModels
{
    public class CategoryRequestModel
    {
        [Required]
        public string Name { get; set; }

        public long? SuperCategoryId { get; set; } = null;
    }
}
