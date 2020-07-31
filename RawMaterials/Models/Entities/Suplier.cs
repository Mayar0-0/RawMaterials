using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RawMaterials.Models.Entities
{
    public class Suplier : User
    {

        public bool PremiumAccount { get; set; }

        public float Rank { get; set; }

        [Required]
        public string CommericialRecord { get; set; }

        public virtual List<SuplierCategory> SuplierCategories { get; set; }

        public virtual List<FeedBack> FeedBacks { get; set; }

        public virtual List<SuplierMaterial> SuplierMaterials { get; set; }





    }
}
