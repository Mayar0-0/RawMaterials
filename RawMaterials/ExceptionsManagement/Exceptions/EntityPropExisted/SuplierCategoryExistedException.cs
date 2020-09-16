namespace RawMaterials.ExceptionsManagement.Exceptions.EntityPropExisted
{
    public class SuplierCategoryExistedException : EntityPropExistedException
    {
        public SuplierCategoryExistedException(string value) : base("Category", "name", value) { }
    }
}
