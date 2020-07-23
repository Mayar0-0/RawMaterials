using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RawMaterials.Models.Dto;
using RawMaterials.Models.IO.RequestModels;
using RawMaterials.Models.IO.ResponseModels;

using RawMaterials.Service.IService;
namespace RawMaterials.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "IMPORTER")]
    public class ImporterCategoryController : CrudController<ImporterCategoryResponseModel, ImporterCategoryDto,
            IImporterCategoryService, ImporterCategoryRequestModel>
    {

        public ImporterCategoryController(IImporterCategoryService importerCategoryService, IMapper mapper) : base(importerCategoryService, mapper)
        {

        }

    }
}
