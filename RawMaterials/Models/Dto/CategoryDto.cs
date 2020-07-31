namespace RawMaterials.Models.Dto
{
    public class CategoryDto
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public long? SuperCategoryId { get; set; }

        public CategoryDto SuperCategory { get; set; }


    }
}
