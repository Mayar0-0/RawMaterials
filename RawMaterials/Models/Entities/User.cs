using Microsoft.AspNetCore.Identity;
using RawMaterials.Shared.Enumerations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RawMaterials.Models.Entities
{
    public class User : IdentityUser
    {
        [DefaultValue(true)]
        public bool Active { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public string Address { get; set; }

        [Required]
        public char Gender { get; set; }

        public string Nationality { get; set; }

        public NotificationSetting NotificationSetting { get; set; }

        public List<PaymentInfo> PaymentInfos { get; set; }

        public List<Notification> Notifications { get; set; }

    }
}
