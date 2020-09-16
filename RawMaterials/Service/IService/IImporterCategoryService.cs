using RawMaterials.Models.Dto;
using System.Threading.Tasks;

namespace RawMaterials.Service.IService
{
    public interface IImporterCategoryService : ICrudService<ImporterCategoryDto>
    {
        Task<bool> PutCategorys(ImporterCategoryDto[] ImporterCategoryDtos);

    }
}
