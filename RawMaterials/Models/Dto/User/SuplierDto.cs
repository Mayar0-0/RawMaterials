using System.ComponentModel.DataAnnotations;

namespace RawMaterials.Models.Dto.User
{
    public class SuplierDto : GeneralUserDto
    {
        [Required]
        public string CommericialRecord { get; set; }
    }
}
