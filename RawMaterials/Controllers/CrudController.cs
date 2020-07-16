using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RawMaterials.Models.IO.RequestParams;
using RawMaterials.Repository.PagingAndSorting;
using RawMaterials.Service.IService;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RawMaterials.Controllers
{
    public class CrudController<ResponseModel, ModelDto, IBusinessService, RequestModel> : ControllerBase
        where IBusinessService: ICrudService<ModelDto>
        where ModelDto : class
    {

        private readonly IBusinessService _businessService;
        private readonly IMapper _mapper;

        public CrudController(IBusinessService businessService, IMapper mapper)
        {
            _businessService = businessService;
            _mapper = mapper;
        }

        // GET: api/Category
        [HttpGet]
        public async Task<IEnumerable<ResponseModel>> GetAll([FromQuery] PaginationParams paginationParams)
        {
            var pageable = _mapper.Map<PageAble>(paginationParams);
            return _mapper.Map<ModelDto[], IEnumerable<ResponseModel>>((await _businessService.GetAll(pageable)).ToArray());
        }

        // GET: api/Category/5
        [HttpGet("{id}")]
        public async Task<ResponseModel> Get(int id)
        {
            return _mapper.Map<ResponseModel>(await _businessService.GetSignle(id));
        }

        // POST: api/Category
        [HttpPost]
        public async Task<ResponseModel> Post([FromForm] RequestModel requestModel)
        {
            return _mapper.Map<ResponseModel>(await _businessService.Create(_mapper.Map<ModelDto>(requestModel)));
        }

        // PUT: api/Category/5
        [HttpPut("{id}")]
        public async Task<ResponseModel> Put(int id, [FromForm] RequestModel requestModel)
        {
            return _mapper.Map<ResponseModel>(await _businessService.Update(id, _mapper.Map<ModelDto>(requestModel)));
        }

        // DELETE: api/Category/5
        [HttpDelete("{id}")]
        public async Task<ResponseModel> Delete(int id)
        {
            return _mapper.Map<ResponseModel>(await _businessService.Delete(id));
        }
    }
}
