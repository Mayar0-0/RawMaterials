using AutoMapper;
using RawMaterials.ExceptionsManagement.Exceptions.EntityNotExisted;
using RawMaterials.ExceptionsManagement.Exceptions.EntityPropExisted;
using RawMaterials.Models.Dto;
using RawMaterials.Models.Entities;
using RawMaterials.Repository.IRepository;
using RawMaterials.Service.IService;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace RawMaterials.Service
{
    public class CategoryService : CrudService<CategoryDto, ICategoryRepo, Category, CategoryNotExistedException>, ICategoryService
    {
        public CategoryService(ICategoryRepo categoryRepo, IMapper mapper) : base(categoryRepo, mapper) { }

        internal override async Task CheckCreateRules(CategoryDto categoryDto)
        {
            if (await NameIsExisted(categoryDto.Name))
                throw new CategoryNameExistedException(categoryDto.Name);
        }

        internal async override Task CheckUpdateRules(int id, CategoryDto categoryDto)
        {
            if (await CategoryNameCahnged(id, categoryDto.Name))
                if (await NameIsExisted(categoryDto.Name))
                    throw new CategoryNameExistedException(categoryDto.Name);
        }

        internal override Task CheckDeleteRules(int id)
        {
            return Task.CompletedTask;
        }

        private async Task<bool> CategoryNameCahnged(long id, string name)
        {
            return (await _businessRepo.GetById(id)).Name != name;
        }

        private async Task<bool> NameIsExisted(string name)
        {
            return await _businessRepo.IsExistedByName(name);
        }
        protected override CategoryDto PutId(CategoryDto modelDto, int id)
        {
            modelDto.Id = id;
            return modelDto;
        }

        internal override Expression<Func<Category, bool>> CheckGetRules()
        {
            return null;
        }
    }
}
