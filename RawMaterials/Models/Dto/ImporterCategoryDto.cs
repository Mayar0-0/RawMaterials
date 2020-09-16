using RawMaterials.Models.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace RawMaterials.Models.Dto
{
    public class ImporterCategoryDto
    {
        public long? Id { get; set; } = 0;
        public virtual Category Category { get; set; }

        public long CategoryId { get; set; }

        public virtual Importer Suplier { get; set; }

        public string ImporterId { get; set; }

        [NotMapped]
        public bool IsDestroyed { get; set; }
    }
}
