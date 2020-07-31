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
    [Authorize(Roles = "IMPORTER")]
    public class ImporterCategoryController : CrudController<ImporterCategoryResponseModel, ImporterCategoryDto,
            IImporterCategoryService, ImporterCategoryRequestModel>
    {
        private readonly IImporterCategoryService _importerCategoryService;
        private readonly IMapper _mapper;

        public ImporterCategoryController(IImporterCategoryService importerCategoryService, IMapper mapper) : base(importerCategoryService, mapper)
        {
            _importerCategoryService = importerCategoryService;
            _mapper = mapper;

        }

        [HttpPut]
        public async Task<ActionResult> PutCategory([FromBody] ImporterCategoryRequestModel[] importerCategoryResponseModel)
        {
            var map = _mapper.Map<ImporterCategoryDto[]>(importerCategoryResponseModel);
            bool result = await _importerCategoryService.PutCategorys(map);

            return Ok(result);
        }


    }
}
