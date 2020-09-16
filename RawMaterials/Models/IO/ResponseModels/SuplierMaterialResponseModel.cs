using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Threading.Tasks;

namespace RawMaterials.Models.IO.ResponseModels
{
    public class SuplierMaterialResponseModel
    {
        public long Id { get; set; }

        public long MaterialId { get; set; }

        public string MaterialName { get; set; }

        public string CityName { get; set; }

        public long CityId { get; set; }

        public double Price { get; set; }

        public long Quantitiy { get; set; }

    }
}
