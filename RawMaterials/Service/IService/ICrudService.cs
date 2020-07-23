using RawMaterials.Repository.PagingAndSorting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace RawMaterials.Service.IService
{
    public interface ICrudService<ModelDto> where ModelDto : class
    {
        Task<IEnumerable<ModelDto>> GetAll(PageAble pageable);
        Task<ModelDto> GetSignle(int id);
        Task<ModelDto> Create(ModelDto modelDto);
        Task<ModelDto> Update(int id, ModelDto modelDto);
        Task<ModelDto> Delete(int id);
        Task<IEnumerable<ModelDto>> GetWhere(Expression<Func<ModelDto, bool>> predicate);

    }
}
