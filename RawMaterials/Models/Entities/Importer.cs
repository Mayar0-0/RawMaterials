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

        public List<InterestMaterial> InterestMaterials { get; set; }

        public List<EndedDeal> EndedDeals { get; set; }

        public List<ImporterCategory> ImporterCategories { get; set; }

        public List<FeedBack> FeedBacks { get; set; }

    }
}
