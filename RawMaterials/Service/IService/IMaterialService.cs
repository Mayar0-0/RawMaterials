using RawMaterials.Models.Dto;
using RawMaterials.Models.Entities;
using RawMaterials.Repository.PagingAndSorting;

namespace RawMaterials.Service.IService
{
    public interface IMaterialService: ICrudService<MaterialDto>
    {
    }
}
