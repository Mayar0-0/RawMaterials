using Microsoft.EntityFrameworkCore;
using RawMaterials.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RawMaterials.Repository.PagingAndSorting
{
    public class PagingAndSorting<T> : GenericRepo<T>, IPagingAndSorting<T> where T : class
    {
        public PagingAndSorting(RawMaterialsContext context) : base(context) { }


        public async Task<IEnumerable<T>> GetAll(PageAble pageable)
        {
            return await GetAll()
                .Skip((pageable.PageNumber - 1) * pageable.PageSize)
                .Take(pageable.PageSize)
                .ToListAsync();
        }
    }
}
