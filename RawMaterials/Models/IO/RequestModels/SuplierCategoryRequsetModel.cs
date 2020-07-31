using System.ComponentModel.DataAnnotations;

namespace RawMaterials.Models.IO.RequestModels
{
    public class SuplierCategoryRequsetModel
    {

        public long Id { get; set; } = 0 ;

        [Required]
        public long CategoryId { get; set; }

        [Required]
        public bool IsDestroyed  { get; set; }
    }
}
