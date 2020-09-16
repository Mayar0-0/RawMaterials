using System.Collections.Generic;

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
