using RawMaterials.Data;
using RawMaterials.Models.Entities;
using RawMaterials.Models.IRepository;
using RawMaterials.Repository;

namespace RawMaterials.Models.Repository
{
    public class UserRepo : GenericRepo<User>, IUserRepo
    {
        public UserRepo(RawMaterialsContext context) : base(context) { }

        public User Authentication(string name, string pass)
        {
            throw new System.NotImplementedException();
        }

        public bool IsUniquser(string name)
        {
            throw new System.NotImplementedException();
        }

        public User Register(string name, string pass)
        {
            throw new System.NotImplementedException();
        }
    }
}
