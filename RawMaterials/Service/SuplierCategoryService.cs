using AutoMapper;
using Microsoft.AspNetCore.Identity;
using RawMaterials.Models.Dto;

using RawMaterials.Models.IO.RequestModels;
using RawMaterials.Models.IO.ResponseModels;
using RawMaterials.Repository.IRepository;
using RawMaterials.Service.IService;
using System;

using System.Threading.Tasks;
using System.Transactions;
using RawMaterials.ExceptionsManagement.Exceptions.EntityNotExisted;
using System.Security.Claims;
using System.Security.Principal;
using System.Net.Http;
using Microsoft.AspNetCore.Http;
using RawMaterials.Models.Entities;
using RawMaterials.ExceptionsManagement.Exceptions.EntityPropExisted;
using System.Linq;
using System.Linq.Expressions;

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


    }
}
