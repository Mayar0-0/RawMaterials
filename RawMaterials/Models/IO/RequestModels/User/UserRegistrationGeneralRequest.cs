using RawMaterials.Shared.Enumerations;
using System;
using System.ComponentModel.DataAnnotations;

namespace RawMaterials.Models.IO.RequestModels.User
{
    // on request recive, we don't have idea what the Object type is
    public class UserRegistrationGeneralRequest
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public string Address { get; set; }

        [Required]
        public Gender Gender { get; set; }

        public string Nationality { get; set; }

        public string Field_Name { get; set; }

        public string CommericialRecord { get; set; }

        [Required]
        public string UserRole { get; set; }

    }
}
