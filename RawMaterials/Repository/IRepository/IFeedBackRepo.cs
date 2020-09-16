using RawMaterials.Models.Entities;
using RawMaterials.Repository.PagingAndSorting;
using System.Threading.Tasks;

namespace RawMaterials.Repository.IRepository
{
    public interface IFeedBackRepo : IPagingAndSorting<FeedBack>
    {
        Task<bool> IsExistedBySuplierId(string SuplierId, string ImporterId);
    }
}
