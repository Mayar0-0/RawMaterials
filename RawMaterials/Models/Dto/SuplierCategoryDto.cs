using Newtonsoft.Json;
using RawMaterials.Models.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace RawMaterials.Models.Dto
{
    public class SuplierCategoryDto
    {
        public long ? Id { get; set; } = 0;
        public virtual Category Category { get; set; }

        public long CategoryId { get; set; }

        public virtual Suplier Suplier { get; set; }

        public string SuplierId { get; set; }

        [NotMapped]
        public bool IsDestroyed { get; set; }

    }


}
