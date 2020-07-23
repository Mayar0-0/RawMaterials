using RawMaterials.Data;
using RawMaterials.Models.Entities;
using RawMaterials.Repository.IRepository;
using RawMaterials.Repository.PagingAndSorting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RawMaterials.Repository
{
    public class ImporterCategoryRepo : PagingAndSorting<ImporterCategory>, IImporterCategoryRepo
    {
        public ImporterCategoryRepo(RawMaterialsContext ctx) : base(ctx) { }
    }
}
