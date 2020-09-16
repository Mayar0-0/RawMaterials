using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RawMaterials.Models.IO.RequestModels
{
    public class FeedBackRequestModel
    {
        [Required]
        public string SuplierId { get; set; }

        [Required]
        public string Notes { get; set; }

        [Required]
        public int Rate { get; set; }



    }
}
