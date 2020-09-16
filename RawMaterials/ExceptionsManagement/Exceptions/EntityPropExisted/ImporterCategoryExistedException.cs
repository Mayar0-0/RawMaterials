namespace RawMaterials.ExceptionsManagement.Exceptions.EntityPropExisted
{
    public class ImporterCategoryExistedException : EntityPropExistedException
    {
        public ImporterCategoryExistedException(string value) : base("Category", "name", value) { }
    }
}
