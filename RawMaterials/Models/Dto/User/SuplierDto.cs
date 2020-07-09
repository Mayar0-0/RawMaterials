using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RawMaterials.Models.Dto.User
{
    public class SuplierDto: GeneralUserDto
    {
        [Required]
        public string CommericialRecord { get; set; }
    }
}
