using System;

namespace RawMaterials.Models.Entities
{
    public class PriceLog
    {
        public long Id { get; set; }

        public virtual SuplierMaterial SuplierMaterial { get; set; }

        public long SuplierMaterialId { get; set; }

        public double Price { get; set; }

        public DateTime Date { get; set; }
    }
}
