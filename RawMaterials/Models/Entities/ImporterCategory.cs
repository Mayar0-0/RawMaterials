using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RawMaterials.Models.Entities
{
    public class ImporterCategory
    {
        public long Id { get; set; }

        public Category Category { get; set; }

        public long CategoryId { get; set; }

        public Importer Importer { get; set; }

        public long ImporterId { get; set; }

       

    }
}
