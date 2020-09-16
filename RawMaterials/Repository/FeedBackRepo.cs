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
    public class FeedBackRepo : PagingAndSorting<FeedBack>, IFeedBackRepo
    {
        public FeedBackRepo(RawMaterialsContext ctx) : base(ctx) { }

        public async Task<bool> IsExistedBySuplierId(string SuplierId, string ImporterId)
        {
            Expression<Func<FeedBack, bool>> FindBySuplierIdAndImporterId(string SuplierId, string ImporterId)
            {
                return FeedBack => FeedBack.SuplierId == SuplierId && FeedBack.ImporterId == ImporterId;
            }
            return (await GetWhere(FindBySuplierIdAndImporterId(SuplierId, ImporterId))).ToArray().Length != 0;
        }
    }
}
