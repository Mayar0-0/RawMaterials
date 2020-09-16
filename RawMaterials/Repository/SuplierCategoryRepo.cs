using RawMaterials.Data;
using RawMaterials.Models.Entities;
using RawMaterials.Repository.IRepository;
using RawMaterials.Repository.PagingAndSorting;

namespace RawMaterials.Repository
{
    public class SuplierCategoryRepo : PagingAndSorting<SuplierCategory>, ISuplierCategoryRepo

    {
        public SuplierCategoryRepo(RawMaterialsContext ctx) : base(ctx) { }


    }
}
