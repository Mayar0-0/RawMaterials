using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using RawMaterials.ExceptionsManagement;
using RawMaterials.ExceptionsManagement.Exceptions.EntityNotExisted;
using RawMaterials.ExceptionsManagement.Exceptions.EntityPropExisted;
using RawMaterials.Models.Dto;
using RawMaterials.Models.Entities;
using RawMaterials.Repository.IRepository;
using RawMaterials.Repository.PagingAndSorting;
using RawMaterials.Service.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace RawMaterials.Service
{
    public class SuplierMaterialService : CrudService<SuplierMaterialDto, ISuplierMaterialRepo, SuplierMaterial, SuplierMaterialNotExistedException>, ISuplierMaterialService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<User> _userManager;

        //FIXME: getAll

        public SuplierMaterialService(ISuplierMaterialRepo suplierMaterialRepo, IMapper mapper, IHttpContextAccessor httpContextAccessor, UserManager<User> userManager) : base(suplierMaterialRepo, mapper) {
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
        }

        internal override async Task CheckCreateRules(SuplierMaterialDto suplierMaterialDto)
        {
            string userId = _userManager.GetUserId(_httpContextAccessor.HttpContext.User);

            if (await MaterialIdIsExisted(suplierMaterialDto.MaterialId))
                throw new SuplierMaterialExistedException(suplierMaterialDto.MaterialId.ToString());

            suplierMaterialDto.SuplierId = userId;
        }

        internal async override Task CheckUpdateRules(int id, SuplierMaterialDto suplierMaterialDto)
        {
            string userId = _userManager.GetUserId(_httpContextAccessor.HttpContext.User);
            suplierMaterialDto.SuplierId = userId;

            if (await MaterialIdChanged(id, suplierMaterialDto.MaterialId))
                    throw new SuplierMaterialMaterialIdChangedException();
        }

        internal override Task CheckDeleteRules(int id)
        {
            return Task.CompletedTask;
        }

        private async Task<bool> MaterialIdChanged(long id, long materialId)
        {
            return (await _businessRepo.GetById(id)).MaterialId != materialId;
        }

        private async Task<bool> MaterialIdIsExisted(long materialId)
        {
            var suplierId = _userManager.GetUserId(_httpContextAccessor.HttpContext.User);

            return await _businessRepo.IsExistedByMaterial(materialId, suplierId);
        }
        protected override SuplierMaterialDto PutId(SuplierMaterialDto modelDto, int id)
        {
            modelDto.Id = id;
            return modelDto;
        }

        internal override Expression<Func<SuplierMaterial, bool>> CheckGetRules()
        {
            var suplierId = _userManager.GetUserId(_httpContextAccessor.HttpContext.User);
            return suplierMaterial => suplierMaterial.SuplierId == suplierId;
        }
    }
}
