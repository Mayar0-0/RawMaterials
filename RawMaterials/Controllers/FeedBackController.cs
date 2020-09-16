using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RawMaterials.Models.Dto;
using RawMaterials.Models.IO.RequestModels;
using RawMaterials.Models.IO.ResponseModels;
using RawMaterials.Service.IService;
using System.Threading.Tasks;

namespace RawMaterials.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "IMPORTER")]

    public class FeedBackController : CrudController<FeedBackResponseModel, FeedBackDto, IFeedBackService, FeedBackRequestModel>
    {
        public FeedBackController(IFeedBackService feedBackService, IMapper mapper) :base(feedBackService, mapper)
        {
        }

        // GET: api/feedback/suplier/5
        [Route("~/suplier")]
        [HttpGet("{id}")]
        public async Task<FeedBackResponseModel> GetBySuplier(string id)
        {
            return _mapper.Map<FeedBackResponseModel>(await _businessService.GetBySuplierId(id));
        }
    }
}
