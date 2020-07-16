using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

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

        public virtual NotificationSetting NotificationSetting { get; set; }

        public virtual List<PaymentInfo> PaymentInfos { get; set; }

        public virtual List<Notification> Notifications { get; set; }

    }
}
