using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RawMaterials.Models.IO.RequestModels
{
    public class SuplierMaterialRequestModel
    {
        [Required]
        public long MaterialId { get; set; }

        public long CityId { get; set; }

        [Required]
        public double Price { get; set; }

        public long Quantitiy { get; set; }

    }
}
