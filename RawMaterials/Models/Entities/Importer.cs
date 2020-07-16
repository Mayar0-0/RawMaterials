using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RawMaterials.Models.Entities
{
    public class Importer : User
    {
        public bool PremiumAccount { get; set; }

        public virtual List<InterestMaterial> InterestMaterials { get; set; }

        public virtual List<EndedDeal> EndedDeals { get; set; }

        public virtual List<ImporterCategory> ImporterCategories { get; set; }

        public virtual List<FeedBack> FeedBacks { get; set; }

    }
}
