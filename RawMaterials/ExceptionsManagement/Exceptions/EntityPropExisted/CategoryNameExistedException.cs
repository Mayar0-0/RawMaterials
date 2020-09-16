namespace RawMaterials.ExceptionsManagement.Exceptions.EntityPropExisted
{
    public class CategoryNameExistedException : EntityPropExistedException
    {
        public CategoryNameExistedException(string value) : base("category", "name", value) { }
    }
}
