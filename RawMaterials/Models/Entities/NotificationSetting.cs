namespace RawMaterials.Models.Entities
{
    public class NotificationSetting
    {
        public long Id { get; set; }
        public string UserId { get; set; }

        public virtual User User { get; set; }

        public float BestDealPeriod { get; set; }


    }
}
