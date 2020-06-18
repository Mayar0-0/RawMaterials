using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;

namespace RawMaterials.Models.Entities
{
    public class SuplierMaterial
    {
        public long Id { get; set; }
        public Material Material { get; set; }

        public long MaterialId { get; set; }

        public Suplier Suplier { get; set; }

        public long SuplierId { get; set; }

        public City City { get; set; }

        public long CityId { get; set; }

        public double Price { get; set; }

        public long Quantitiy { get; set; }

        public List<EndedDeal> EndedDeals { get; set; }

        // public long Tax { get; set; }

        // public long ShippingCost { get; set; }

        // public string Status { get; set }
    }
}
