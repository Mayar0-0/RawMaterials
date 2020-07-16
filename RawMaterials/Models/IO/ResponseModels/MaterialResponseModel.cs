namespace RawMaterials.Models.IO.ResponseModels
{
    public class MaterialResponseModel
    {
        public long Id { get; set; }

        public CategoryResponseModelMin Category { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}
