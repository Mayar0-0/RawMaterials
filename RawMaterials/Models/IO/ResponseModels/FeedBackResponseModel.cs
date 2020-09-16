using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Threading.Tasks;

namespace RawMaterials.Models.IO.ResponseModels
{
    public class FeedBackResponseModel
    {
        public long Id { get; set; }

        public string SuplierId { get; set; }

        public int Rate { get; set; }

        public string Notes { get; set; }

    }
}
