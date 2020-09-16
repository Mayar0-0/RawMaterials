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
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace RawMaterials.Service
{
    public class FeedBackService : CrudService<FeedBackDto, IFeedBackRepo, FeedBack, FeedBackNotExistedException>, IFeedBackService
    {

        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<User> _userManager;

        public FeedBackService(IFeedBackRepo feedBackRepo, IMapper mapper, IHttpContextAccessor httpContextAccessor, UserManager<User> userManager) : base(feedBackRepo, mapper) {
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
        }

        internal override async Task CheckCreateRules(FeedBackDto feedBackDto)
        {
            string userId = _userManager.GetUserId(_httpContextAccessor.HttpContext.User);

            if (await SuplierIdIsExisted(feedBackDto.SuplierId, userId))
                throw new FeedBackSuplierIdExistedException(feedBackDto.SuplierId);

            feedBackDto.ImporterId = userId;

        }

        internal override Task CheckUpdateRules(int id, FeedBackDto feedBackDto)
        {
            string userId = _userManager.GetUserId(_httpContextAccessor.HttpContext.User);
            feedBackDto.ImporterId = userId;

            return Task.CompletedTask;
        }

        internal override Task CheckDeleteRules(int id)
        {
            return Task.CompletedTask;
        }

        private async Task<bool> SuplierIdIsExisted(string suplierId, string importerId)
        {
            return await _businessRepo.IsExistedBySuplierId(suplierId, importerId);
        }
        protected override FeedBackDto PutId(FeedBackDto feedBackDto, int id)
        {
            feedBackDto.Id = id;
            return feedBackDto;
        }

        internal override Expression<Func<FeedBack, bool>> CheckGetRules()
        {
            var importerId = _userManager.GetUserId(_httpContextAccessor.HttpContext.User);
            return feedBack => feedBack.ImporterId == importerId;
        }

        public async Task<object> GetBySuplierId(string id)
        {
            return _mapper.Map<FeedBack[], IEnumerable<FeedBackDto>>((await _businessRepo.GetWhere(feedBack => feedBack.SuplierId == id)).ToArray());
        }

    }
}
