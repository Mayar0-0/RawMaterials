using RawMaterials.Models.Entities;
using RawMaterials.Repository.PagingAndSorting;
using System.Threading.Tasks;

namespace RawMaterials.Repository.IRepository
{
    public interface IMaterialRepo : IPagingAndSorting<Material>
    {
        Task<bool> IsExistedByName(string MaterialName);
    }
}
