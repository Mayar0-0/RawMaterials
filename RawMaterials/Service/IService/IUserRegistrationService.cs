using Microsoft.AspNetCore.Mvc.ActionConstraints;
using RawMaterials.Models.Dto.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RawMaterials.Service.IService
{
    public interface IUserRegistrationService
    {
        public Task<ImporterDto> registerImporter(ImporterDto importerDto);
        public Task<SuplierDto> registerSuplier(SuplierDto suplierDto);
        public Task<TeamWorkDto> registerTeamWork(TeamWorkDto tramWorkDto);

    }
}
