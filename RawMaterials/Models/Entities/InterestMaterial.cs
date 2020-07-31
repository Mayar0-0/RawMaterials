namespace RawMaterials.Models.Entities
{
    public class InterestMaterial
    {
        public long Id { get; set; }

        public virtual SuplierMaterial SuplierMterial { get; set; }

        public long SuplierMterialId { get; set; }

        public virtual Importer Importer { get; set; }

        public string ImporterId { get; set; }
    }
}
