using RawMaterials.Data;
using RawMaterials.Models.Entities;
using RawMaterials.Repository.IRepository;
using RawMaterials.Repository.PagingAndSorting;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace RawMaterials.Repository
{
    public class MaterialRepo : PagingAndSorting<Material>, IMaterialRepo
    {
        public MaterialRepo(RawMaterialsContext ctx) : base(ctx) { }

        public async Task<bool> IsExistedByName(string MaterialName)
        {
            Expression<Func<Material, bool>> FindByName(string MaterialName)
            {
                return Material => Material.Name == MaterialName;
            }
            return (await GetWhere(FindByName(MaterialName))).ToArray().Length != 0;
        }
    }
}
