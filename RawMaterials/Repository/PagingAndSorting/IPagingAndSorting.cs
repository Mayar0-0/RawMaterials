using RawMaterials.Models.IRepository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RawMaterials.Repository.PagingAndSorting
{
    public interface IPagingAndSorting<T> : IGenericRepo<T> where T : class
    {
        Task<IEnumerable<T>> GetAll(PageAble pageable);
    }
}
