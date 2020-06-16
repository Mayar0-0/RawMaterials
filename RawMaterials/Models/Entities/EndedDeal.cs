using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;

namespace RawMaterials.Models.Entities
{
    public class EndedDeal
    {
        public long Id { get; set; }

        public Importer Importer { get; set; }

        public int ImporterId { get; set; }

        public SuplierMaterial SuplierMaterial { get; set; }

        public long SuplierMaterialId { get; set; }

        public int Quantity { get; set; }

        public DateTime Date { get; set; }

        public string Notes { get; set; }
    }
}
