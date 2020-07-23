using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RawMaterials.Models.IO.RequestModels
{
    public class ImporterCategoryRequestModel
    {

        [Required]
        public long CategoryId { get; set; }
    }
}
