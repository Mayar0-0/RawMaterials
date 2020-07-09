using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RawMaterials.Models.Dto.User
{
    public class LoginDto
    {
        public string UserName { get; set; }

        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
