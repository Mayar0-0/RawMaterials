using RawMaterials.Models.Entities;
using RawMaterials.Repository.PagingAndSorting;
using System.Threading.Tasks;

namespace RawMaterials.Repository.IRepository
{
    public interface ISuplierMaterialRepo : IPagingAndSorting<SuplierMaterial>
    {
        Task<bool> IsExistedByMaterial(long MaterialId, string suplierId);
    }
}
