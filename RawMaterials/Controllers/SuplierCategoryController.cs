using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RawMaterials.Models.Dto;
using RawMaterials.Models.IO.RequestModels;
using RawMaterials.Models.IO.ResponseModels;
using RawMaterials.Service;
using RawMaterials.Service.IService;

namespace RawMaterials.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "SUPLIER")]
    public class SuplierCategoryController : CrudController<SuplierCategoryResponseModel, SuplierCategoryDto,
            ISuplierCategoryService, SuplierCategoryRequsetModel>
    {        
        public SuplierCategoryController(ISuplierCategoryService suplierCategoryService, IMapper mapper) : base(suplierCategoryService, mapper)
        {
            
        }
       


    }
}
