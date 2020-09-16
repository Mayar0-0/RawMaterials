using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RawMaterials.Models.Dto
{
    public class FeedBackDto
    {
        public long Id { get; set; }

        public string SuplierId { get; set; }

        public string ImporterId { get; set; }

        public int Rate { get; set; }

        public string Notes { get; set; }


    }
}
