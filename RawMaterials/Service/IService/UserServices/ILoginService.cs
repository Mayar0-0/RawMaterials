using RawMaterials.Models.Dto.User;
using RawMaterials.Models.IO.ResponseModels.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RawMaterials.Service.IService.UserServices
{
    public interface ILoginService
    {
        public Task<LoginResponseModel> Login(LoginDto loginDto);
    }
}
