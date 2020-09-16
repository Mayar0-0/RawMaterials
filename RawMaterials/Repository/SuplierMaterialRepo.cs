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
    public class SuplierMaterialRepo : PagingAndSorting<SuplierMaterial>, ISuplierMaterialRepo
    {
        public SuplierMaterialRepo(RawMaterialsContext ctx) : base(ctx) { }

        public async Task<bool> IsExistedByMaterial(long MaterialId, string SuplierId)
        {
            Expression<Func<SuplierMaterial, bool>> FindByMaterialId(long MaterialId, string SuplierId)
            {
                return SuplierMaterial => SuplierMaterial.MaterialId == MaterialId && SuplierMaterial.SuplierId == SuplierId;
            }
            return (await GetWhere(FindByMaterialId(MaterialId, SuplierId))).ToArray().Length != 0;
        }

    }
}
