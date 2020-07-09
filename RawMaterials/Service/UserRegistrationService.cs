using AutoMapper;
using Microsoft.AspNetCore.Identity;
using RawMaterials.ExceptionsManagement;
using RawMaterials.Models.Dto.User;
using RawMaterials.Models.Entities;
using RawMaterials.Service.IService;
using RawMaterials.Shared.Enumerations;
using System.Linq;
using System.Threading.Tasks;

namespace RawMaterials.Service
{
    public class UserRegistrationService : IUserRegistrationService
    {
        private readonly IMapper _mapper;
        private UserManager<User> _userManager;
        private UserManager<Importer> _importerManager;
        private UserManager<Suplier> _suplierManager;
        private UserManager<TeamWork> _teamWorkManager;



        public UserRegistrationService(IMapper mapper,UserManager<User> userManager, UserManager<Importer> importerManager, UserManager<Suplier> suplierManager, UserManager<TeamWork> teamWorkManager)
        {
            _mapper = mapper;
            _importerManager = importerManager;
            _suplierManager = suplierManager;
            _teamWorkManager = teamWorkManager;
            _userManager = userManager;

        }

        public async Task<ImporterDto> registerImporter(ImporterDto importerDto)
        {
            var ImporterEntity = _mapper.Map<Importer>(importerDto);

            await CheckNameDublication(importerDto.UserName);

            IdentityResult result = await _importerManager.CreateAsync(ImporterEntity, importerDto.Password);
            if (!result.Succeeded)
                throw new UserRegistrationException(string.Join(", \n", result.Errors.Select(err => err.Description)));

            await _importerManager.AddToRoleAsync(ImporterEntity, SystemRoles.IMPORTER.ToString());


            var importerResult = await _importerManager.FindByNameAsync(importerDto.UserName);

            return _mapper.Map<ImporterDto>(importerResult);

        }



        public async Task<SuplierDto> registerSuplier(SuplierDto suplierDto)
        {
            var SuplierEntity = _mapper.Map<Suplier>(suplierDto);

            await CheckNameDublication(suplierDto.UserName);


            IdentityResult result = await _suplierManager.CreateAsync(SuplierEntity, suplierDto.Password);
            if (!result.Succeeded)
                throw new UserRegistrationException(string.Join(", \n", result.Errors.Select(err => err.Description)));


            await _suplierManager.AddToRoleAsync(SuplierEntity, SystemRoles.SUPLIER.ToString());


            var suplierResult = await _suplierManager.FindByNameAsync(suplierDto.UserName);

            return _mapper.Map<SuplierDto>(suplierResult);
        }

        public async Task<TeamWorkDto> registerTeamWork(TeamWorkDto tramWorkDto)
        {
            var TeamWorkerEntity = _mapper.Map<TeamWork>(tramWorkDto);

            await CheckNameDublication(tramWorkDto.UserName);


            IdentityResult result = await _teamWorkManager.CreateAsync(TeamWorkerEntity, tramWorkDto.Password);
            if (!result.Succeeded)
                throw new UserRegistrationException(string.Join(", \n", result.Errors.Select(err => err.Description)));

            await _teamWorkManager.AddToRoleAsync(TeamWorkerEntity, SystemRoles.TEAMWORK.ToString());

            var teamWorkResult = await _teamWorkManager.FindByNameAsync(tramWorkDto.UserName);

            return _mapper.Map<TeamWorkDto>(teamWorkResult);
        }

        private async Task CheckNameDublication(string UserName)
        {
            if (await _userManager.FindByNameAsync(UserName) != null)
                throw new UserRegistrationException($"User name '{UserName}' is already taken.");
        }

    }
}
