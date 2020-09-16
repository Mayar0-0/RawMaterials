using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RawMaterials.Models.Dto;
using RawMaterials.Models.IO.RequestModels;
using RawMaterials.Models.IO.ResponseModels;
using RawMaterials.Service.IService;

namespace RawMaterials.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaterialController : CrudController<MaterialResponseModel, MaterialDto, IMaterialService, MaterialRequestModel>
    {
        public MaterialController(IMaterialService _materialService, IMapper mapper) : base(_materialService, mapper) { }

    }
}
