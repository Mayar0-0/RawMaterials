using RawMaterials.Data;
using RawMaterials.Models.Entities;
using RawMaterials.Repository.IRepository;
using RawMaterials.Repository.PagingAndSorting;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace RawMaterials.Repository
{
    public class CategoryRepo : PagingAndSorting<Category>, ICategoryRepo
    {
        public CategoryRepo(RawMaterialsContext ctx) : base(ctx) { }

        public async Task<bool> IsExistedByName(string CategoryName)
        {
            Expression<Func<Category, bool>> FindByName(string CategoryName)
            {
                return Category => Category.Name == CategoryName;
            }
            return (await GetWhere(FindByName(CategoryName))).ToArray().Length != 0;
        }
    }
}
