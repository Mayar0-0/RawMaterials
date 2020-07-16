using RawMaterials.Models.Dto;
using RawMaterials.Models.Dto.User;
using RawMaterials.Repository.PagingAndSorting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RawMaterials.Service.IService
{
    public interface ICategoryService : ICrudService<CategoryDto>
    {
        //public Task<CategoryDto> CreateCategory(CategoryDto categoryDto);
        //public Task<IEnumerable<CategoryDto>> GetCategories(PageAble pageable);
        //public Task<CategoryDto> GetSignleCategory(long id);
        //public Task<CategoryDto> UpdateCategory(long id, CategoryDto categoryDto);
        //public Task<CategoryDto> DeleteCategory(long id);

    }
}
