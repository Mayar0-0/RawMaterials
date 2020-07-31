namespace RawMaterials.Models.IO.ResponseModels
{
    public class CategoryResponseModel
    {
        public string Name { get; set; }

        public long Id { get; set; }

        public long? SuperCategoryId { get; set; }

        public CategoryResponseModelMin SuperCategory { get; set; }

    }
}
