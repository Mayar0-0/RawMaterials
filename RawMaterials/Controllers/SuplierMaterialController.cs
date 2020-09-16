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
    [Authorize(Roles = "SUPLIER")]
    public class SuplierMaterialController : CrudController<SuplierMaterialResponseModel, SuplierMaterialDto, ISuplierMaterialService, SuplierMaterialRequestModel>
    {
        public SuplierMaterialController(ISuplierMaterialService suplierMaterialService, IMapper mapper) :base(suplierMaterialService, mapper)
        {
        }
    }
}
