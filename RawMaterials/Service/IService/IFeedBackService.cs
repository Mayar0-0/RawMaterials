using RawMaterials.Models.Dto;
using RawMaterials.Models.Dto.User;
using RawMaterials.Repository.PagingAndSorting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RawMaterials.Service.IService
{
    public interface IFeedBackService : ICrudService<FeedBackDto>
    {
        Task<object> GetBySuplierId(string id);
    }
}
