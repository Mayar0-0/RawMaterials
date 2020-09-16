using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RawMaterials.ExceptionsManagement;
using RawMaterials.Models.Dto.User;
using RawMaterials.Models.IO.RequestModels.User;
using RawMaterials.Models.IO.ResponseModels.User;
using RawMaterials.Service.IService.UserServices;
using RawMaterials.Shared.Enumerations;
using System.Threading.Tasks;

namespace RawMaterials.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMapper _mapper;
        private IUserRegistrationService _userRegistrationService;
        private ILoginService _loginService;

        static readonly string importerRole = SystemRoles.IMPORTER.ToString();

        public UserController(IMapper mapper, IUserRegistrationService userRegistrationService, ILoginService loginService)
        {
            _mapper = mapper;
            _userRegistrationService = userRegistrationService;
            _loginService = loginService;
        }

        [HttpPost("")]
        public async Task<IActionResult> Register([FromForm] UserRegistrationGeneralRequest UserModel)
        {
            if (UserModel.UserRole == null)
                throw new UserRegistrationException("user registration information should have a role", true);

            //validaty

            switch (UserModel.UserRole)
            {
                case "IMPORTER":
                    var importerDto = _mapper.Map<ImporterDto>(UserModel);
                    return Ok(_mapper.Map<ImporterRegistrationResponse>(await _userRegistrationService.registerImporter(importerDto)));

                case "SUPLIER":
                    var suplierDto = _mapper.Map<SuplierDto>(UserModel);
                    return Ok(_mapper.Map<SuplierRegistrationResponse>(await _userRegistrationService.registerSuplier(suplierDto)));

                case "TEAMWORK":
                    var teamWorkDto = _mapper.Map<TeamWorkDto>(UserModel);
                    return Ok(_mapper.Map<TeamWorkRegistrationResponse>(await _userRegistrationService.registerTeamWork(teamWorkDto)));
            }
            return BadRequest(new { message = "user role should be [ Importer, Suplier, TeamWork ]" });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromForm] LoginRequestModel loginRequestModel)
        {
            var loginDto = _mapper.Map<LoginDto>(loginRequestModel);
            var loginResponseModel = await _loginService.Login(loginDto);


            if (loginResponseModel.Succeed)
                return Ok(loginResponseModel);
            else
                return BadRequest(loginResponseModel);

        }


    }
}
