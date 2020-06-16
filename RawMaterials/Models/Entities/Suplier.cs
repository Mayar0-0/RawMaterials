using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RawMaterials.Models.Entities
{
    public class Suplier : User
    {

        public bool PremiumAccount { get; set; }

        public float Rank { get; set; }

        public string CommericialRecord { get; set; }

        public List<SuplierCategory> SuplierCategories { get; set; }

        public List<FeedBack> FeedBacks { get; set; }

        public List<SuplierMaterial> SuplierMaterials { get; set; }





    }
}
