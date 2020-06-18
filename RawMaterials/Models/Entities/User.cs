﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RawMaterials.Models.Entities
{
    public class User
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Active { get; set; }

        public DateTime BirthDate { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Address { get; set; }

        public string Phone { get; set; }

        public bool Gender { get; set; }

        public string Nationality { get; set; }

        public NotificationSetting NotificationSetting { get; set; }

        public List<PaymentInfo> PaymentInfos { get; set; }

        public List<Notification> Notifications { get; set; }

    }
}
