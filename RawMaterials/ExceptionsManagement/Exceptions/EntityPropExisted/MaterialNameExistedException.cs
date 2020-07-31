namespace RawMaterials.ExceptionsManagement.Exceptions.EntityPropExisted
{
    public class MaterialNameExistedException : EntityPropExistedException
    {
        public MaterialNameExistedException(string value) : base("material", "name", value) { }
    }
}
