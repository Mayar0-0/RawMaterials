using System.ComponentModel.DataAnnotations;

namespace RawMaterials.Models.IO.RequestModels.User
{
    public class LoginRequestModel
    {
        [Required]
        public string UserNameOrEmail { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
