
using AutoMapper;
using RawMaterials.Models.DTO;
using RawMaterials.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RawMaterials.Dto
{
    public class AutoMapping : Profile
    {

        public AutoMapping()
        {
            CreateMap<User, UserReadDto>();
            CreateMap<UserReadDto, User>();
         
            
        }
     

    }
}