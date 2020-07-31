using RawMaterials.Models.Dto.User;
using System.Threading.Tasks;

namespace RawMaterials.Service.IService.UserServices
{
    public interface IUserRegistrationService
    {
        public Task<ImporterDto> registerImporter(ImporterDto importerDto);
        public Task<SuplierDto> registerSuplier(SuplierDto suplierDto);
        public Task<TeamWorkDto> registerTeamWork(TeamWorkDto tramWorkDto);

    }
}
