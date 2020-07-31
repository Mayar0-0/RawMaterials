namespace RawMaterials.Models.IO.ResponseModels
{
    public class CategoryResponseModelMin
    {
        //private CategoryResponseModelMin(bool success, string message) : base(success, message) { }
        //public CategoryResponseModelMin(string message) : this(false, message) { }

        public string Name { get; set; }

        public long Id { get; set; }
    }
}
