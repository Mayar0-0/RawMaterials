using RawMaterials.Models.Entities;
using RawMaterials.Repository.PagingAndSorting;
using System.Threading.Tasks;

namespace RawMaterials.Repository.IRepository
{
    public interface ICategoryRepo : IPagingAndSorting<Category>
    {
        Task<bool> IsExistedByName(string CategoryName);
    }
}
