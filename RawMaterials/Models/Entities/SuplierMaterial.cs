using System.Collections.Generic;

namespace RawMaterials.Models.Entities
{
    public class SuplierMaterial
    {
        public long Id { get; set; }
        public virtual Material Material { get; set; }

        public long MaterialId { get; set; }

        public virtual Suplier Suplier { get; set; }

        public string SuplierId { get; set; }

        public virtual City City { get; set; }

        public long CityId { get; set; }

        public double Price { get; set; }

        public long Quantitiy { get; set; }

        public virtual List<EndedDeal> EndedDeals { get; set; }

        // public long Tax { get; set; }

        // public long ShippingCost { get; set; }

        // public string Status { get; set }
    }
}
