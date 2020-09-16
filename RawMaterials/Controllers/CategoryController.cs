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
    public class CategoryController : CrudController<CategoryResponseModel, CategoryDto, ICategoryService, CategoryRequestModel>
    {
        public CategoryController(ICategoryService categoryService, IMapper mapper) : base(categoryService, mapper)
        {
        }
    }
}
