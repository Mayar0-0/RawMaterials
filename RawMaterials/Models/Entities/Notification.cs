using System;

namespace RawMaterials.Models.Entities
{
    public class Notification
    {
        public long Id { get; set; }

        public virtual User User { get; set; }

        public string UserId { get; set; }

        public string Type { get; set; }

        public string notification_text { get; set; }

        public DateTime Read_at { get; set; }


    }
}
