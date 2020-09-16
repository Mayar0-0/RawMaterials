using RawMaterials.Models.Entities;

namespace RawMaterials.Models.IRepository
{
    public interface IUserRepo : IGenericRepo<User>
    {
        bool IsUniquser(string name);
        User Authentication(string name, string pass);
        User Register(string name, string pass);

    }
}
