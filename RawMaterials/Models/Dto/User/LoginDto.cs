using System.ComponentModel.DataAnnotations;

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
