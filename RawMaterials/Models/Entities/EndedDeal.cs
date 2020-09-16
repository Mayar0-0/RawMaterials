using System;

namespace RawMaterials.Models.Entities
{
    public class EndedDeal
    {
        public long Id { get; set; }

        public virtual Importer Importer { get; set; }

        public string ImporterId { get; set; }

        public virtual SuplierMaterial SuplierMaterial { get; set; }

        public long SuplierMaterialId { get; set; }

        public int Quantity { get; set; }

        public DateTime Date { get; set; }

        public string Notes { get; set; }
    }
}
