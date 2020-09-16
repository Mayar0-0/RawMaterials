using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RawMaterials.Models.Dto;
using RawMaterials.Models.IO.RequestModels;
using RawMaterials.Models.IO.ResponseModels;
using RawMaterials.Service;
using RawMaterials.Service.IService;
using System.Threading.Tasks;

namespace RawMaterials.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "SUPLIER")]
    public class SuplierCategoryController : CrudController<SuplierCategoryResponseModel, SuplierCategoryDto,
            ISuplierCategoryService, SuplierCategoryRequsetModel>
    {

        private readonly ISuplierCategoryService _suplierCategoryService;
        private readonly IMapper _mapper;
        public SuplierCategoryController(ISuplierCategoryService suplierCategoryService, IMapper mapper) : base(suplierCategoryService, mapper)
        {
            _suplierCategoryService = suplierCategoryService;
            _mapper = mapper;
        }


        [HttpPut]
        public async Task<ActionResult> PutCategory([FromBody] SuplierCategoryRequsetModel[]  suplierCategoryRequsetModel)
        {
            var map = _mapper.Map<SuplierCategoryDto[]>(suplierCategoryRequsetModel);
            bool result = await _suplierCategoryService.PutCategorys(map);

            return Ok(result);
        }




    }
}
