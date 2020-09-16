using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using RawMaterials.ExceptionsManagement.Exceptions.EntityNotExisted;
using RawMaterials.ExceptionsManagement.Exceptions.EntityPropExisted;
using RawMaterials.Models.Dto;
using RawMaterials.Models.Entities;
using RawMaterials.Repository.IRepository;
using RawMaterials.Service.IService;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Transactions;

namespace RawMaterials.Service
{
    public class ImporterCategoryService : CrudService<ImporterCategoryDto, IImporterCategoryRepo, ImporterCategory, ImporterCategoryNotExistedException>, IImporterCategoryService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<User> _userManager;

        public ImporterCategoryService(IMapper mapper, IImporterCategoryRepo importerCategoryRepo, IHttpContextAccessor httpContextAccessor, UserManager<User> userManager) : base(importerCategoryRepo, mapper)
        {
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
        }

        protected override ImporterCategoryDto PutId(ImporterCategoryDto modelDto, int id)
        {
            modelDto.Id = id;
            return modelDto;
        }

        internal override async Task CheckCreateRules(ImporterCategoryDto modelDto)
        {
            string userId = _userManager.GetUserId(_httpContextAccessor.HttpContext.User);
            if (await CategoryIsExisted(modelDto.CategoryId, userId))
            {
                throw new ImporterCategoryExistedException("");
            }
            modelDto.ImporterId = userId;
        }

        private async Task<bool> CategoryIsExisted(long Categoryid, string userid)
        {
            var category = await _businessRepo.GetWhere(p => p.CategoryId == Categoryid && p.ImporterId == userid);
            return category.ToArray().Length != 0;
        }

        internal override Task CheckDeleteRules(int id)
        {
            return Task.CompletedTask;

        }

        internal override Task CheckUpdateRules(int id, ImporterCategoryDto modelDto)
        {
            throw new NotImplementedException();
        }

        internal override Expression<Func<ImporterCategory, bool>> CheckGetRules()
        {
            string userId = _userManager.GetUserId(_httpContextAccessor.HttpContext.User);
            return p => p.ImporterId == userId;
        }
        public async Task<bool> PutCategorys(ImporterCategoryDto[] ImporterCategoryDtos)
        {
            string userId = _userManager.GetUserId(_httpContextAccessor.HttpContext.User);
            try
            {
                using (TransactionScope scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    foreach (ImporterCategoryDto importerCategoryDto in ImporterCategoryDtos)
                    {
                        var b = await _businessRepo.GetWhere(r => r.Id == importerCategoryDto.Id);
                        var exist = await CategoryIsExisted(importerCategoryDto.CategoryId, userId);

                        var map = _mapper.Map<ImporterCategoryDto, ImporterCategory>(importerCategoryDto);
                        map.ImporterId = userId;
                        if (b.Count() > 0)
                        {
                            if (importerCategoryDto.IsDestroyed)
                                await _businessRepo.Remove(b.First());
                            else
                            {
                                b.First().CategoryId = map.CategoryId;
                                await _businessRepo.Update(b.First());
                            }

                        }
                        else
                        {
                            switch (exist)
                            {
                                case false: await _businessRepo.Add(map); break;
                                default: throw new ImporterCategoryExistedException("");
                            }
                        }

                    }
                    scope.Complete();
                    return true;
                }
            }
            catch (Exception e)
            {
                Console.Write(e.Message);
                return false;
            }
        }
    }



}
