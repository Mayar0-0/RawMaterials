using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RawMaterials.Models.Entities
{
    public class NotificationSetting
    {
        public long Id { get; set; }
        public long UserId { get; set; }

        public User User { get; set; }

        public float BestDealPeriod { get; set; }


    }
}
