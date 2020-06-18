using RawMaterials.Models.Entities;
using RawMaterials.Models.Repository;
using RawMaterials.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RawMaterials.Models.IRepository
{
    public interface IUserRepo : IGenericRepo<User>
    {
        bool IsUniquser(string name);
        User Authentication(string name, string pass);
        User Register(string name, string pass);

    }
}
