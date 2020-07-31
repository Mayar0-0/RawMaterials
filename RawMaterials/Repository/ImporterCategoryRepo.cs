using RawMaterials.Data;
using RawMaterials.Models.Entities;
using RawMaterials.Repository.IRepository;
using RawMaterials.Repository.PagingAndSorting;

namespace RawMaterials.Repository
{
    public class ImporterCategoryRepo : PagingAndSorting<ImporterCategory>, IImporterCategoryRepo
    {
        public ImporterCategoryRepo(RawMaterialsContext ctx) : base(ctx) { }
    }
}
