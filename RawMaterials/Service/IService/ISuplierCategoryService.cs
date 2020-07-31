using RawMaterials.Models.Dto;
using System.Threading.Tasks;

namespace RawMaterials.Service.IService
{
    public interface ISuplierCategoryService : ICrudService<SuplierCategoryDto>
    {
        Task<bool> PutCategorys(SuplierCategoryDto[] suplierCategoryDtos);


    }
}
