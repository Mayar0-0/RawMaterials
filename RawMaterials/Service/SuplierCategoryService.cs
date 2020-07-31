using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using RawMaterials.Data;
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
    public class SuplierCategoryService : CrudService<SuplierCategoryDto, ISuplierCategoryRepo, SuplierCategory, SuplierCategoryNotExistedException>, ISuplierCategoryService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<User> _userManager;

        public SuplierCategoryService(IMapper mapper, ISuplierCategoryRepo suplierCategoryRepo, IHttpContextAccessor httpContextAccessor, UserManager<User> userManager) : base(suplierCategoryRepo, mapper)
        {
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
        }

        protected override SuplierCategoryDto PutId(SuplierCategoryDto modelDto, int id)
        {
            modelDto.Id = id;
            return modelDto;
        }

        internal override async Task CheckCreateRules(SuplierCategoryDto modelDto)
        {
            string userId = _userManager.GetUserId(_httpContextAccessor.HttpContext.User);
            if (await CategoryIsExisted(modelDto.CategoryId, userId))
            {
                throw new SuplierCategoryExistedException("");
            }
            modelDto.SuplierId = userId;
        }

        private async Task<bool> CategoryIsExisted(long Categoryid, string userid)
        {
            var category = await _businessRepo.GetWhere(p => p.CategoryId == Categoryid && p.SuplierId == userid);
            return category.ToArray().Length != 0;
        }

        internal override Task CheckDeleteRules(int id)
        {
            return Task.CompletedTask;

        }

        internal override Task CheckUpdateRules(int id, SuplierCategoryDto modelDto)
        {
            throw new NotImplementedException();
        }

        internal override Expression<Func<SuplierCategory, bool>> CheckGetRules()
        {
            string userId = _userManager.GetUserId(_httpContextAccessor.HttpContext.User);
            return p => p.SuplierId == userId;
        }

        public async Task<bool> PutCategorys(SuplierCategoryDto[] suplierCategoryDtos)
        {
            string userId = _userManager.GetUserId(_httpContextAccessor.HttpContext.User);

            try
            {
                using (TransactionScope scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    foreach (SuplierCategoryDto suplierCategoryDto in suplierCategoryDtos)
                    {
                        //four status :
                        //1: Destroyed and Exist : delete
                        //2: Destroyed and Not Exist : Nothing
                        //3: Not Destroyed and Exist: Update
                        //4: Not Destroyed and Not Exist: Add

                        //Should get Entity for update not only id 
                        var b = await _businessRepo.GetWhere(r => r.Id == suplierCategoryDto.Id);
                        // user have this Category ?
                        var exist = await CategoryIsExisted(suplierCategoryDto.CategoryId, userId);

                        var map = _mapper.Map<SuplierCategoryDto, SuplierCategory>(suplierCategoryDto);
                        map.SuplierId = userId;

                        if (b.Count() > 0)// id exist in db
                        {
                            if (suplierCategoryDto.IsDestroyed)
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
                                default: throw new SuplierCategoryExistedException("");
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
