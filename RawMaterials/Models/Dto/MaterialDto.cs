namespace RawMaterials.Models.Dto
{
    public class MaterialDto
    {
        public long Id { get; set; }

        public CategoryDto Category { get; set; }

        public long CategoryId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}
