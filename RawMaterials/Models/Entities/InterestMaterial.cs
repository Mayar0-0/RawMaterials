using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RawMaterials.Models.Entities
{
    public class InterestMaterial
    {
        public long Id { get; set; }

        public SuplierMaterial SuplierMterial { get; set; }

        public long SuplierMterialId { get; set; }

        public Importer Importer { get; set; }

        public long ImporterId { get; set; }
    }
}
