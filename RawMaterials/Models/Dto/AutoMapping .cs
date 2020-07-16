
using AutoMapper;
using RawMaterials.Models.Dto;
using RawMaterials.Models.Dto.User;
using RawMaterials.Models.Entities;
using RawMaterials.Models.IO.RequestModels;
using RawMaterials.Models.IO.RequestModels.User;
using RawMaterials.Models.IO.RequestParams;
using RawMaterials.Models.IO.ResponseModels;
using RawMaterials.Models.IO.ResponseModels.User;
using RawMaterials.Repository.PagingAndSorting;
using RawMaterials.Shared.Enumerations;
using RawMaterials.Shared.StaticValues;

namespace RawMaterials.Dto
{
    public class AutoMapping : Profile
    {

        public AutoMapping()
        {
            // Request Params
            CreateMap<PaginationParams, PageAble>();

            // Registration UseCase
            CreateMap<UserRegistrationGeneralRequest, ImporterDto>();
            CreateMap<UserRegistrationGeneralRequest, SuplierDto>();
            CreateMap<UserRegistrationGeneralRequest, TeamWorkDto>();

            CreateMap<GeneralUserDto, User>().ForMember(userModel => userModel.Gender, UserDto => UserDto.MapFrom(userDto => userDto.
            Gender.ToString()[0]));

            CreateMap<User, GeneralUserDto>().ForMember(userDto => userDto.Gender, userModel => userModel.MapFrom(userModel =>
            userModel.Gender.Equals('M') ? Gender.MALE : Gender.FEMALE
            ));

            CreateMap<ImporterDto, Importer>().IncludeBase<GeneralUserDto, User>().ReverseMap();
            CreateMap<SuplierDto, Suplier>().IncludeBase<GeneralUserDto, User>().ReverseMap();
            CreateMap<TeamWorkDto, TeamWork>().IncludeBase<GeneralUserDto, User>().ReverseMap();



            CreateMap<GeneralUserDto, UserRegistrationGeneralResponse>()
                .ForMember(userRes => userRes.Gender, userDto => userDto.MapFrom(userDto => userDto.Gender == Gender.MALE ? "MALE" : "FEMALE"));

            CreateMap<ImporterDto, ImporterRegistrationResponse>().IncludeBase<GeneralUserDto, UserRegistrationGeneralResponse>();
            CreateMap<SuplierDto, SuplierRegistrationResponse>().IncludeBase<GeneralUserDto, UserRegistrationGeneralResponse>();
            CreateMap<TeamWorkDto, TeamWorkRegistrationResponse>().IncludeBase<GeneralUserDto, UserRegistrationGeneralResponse>();



            // login usecase
            CreateMap<LoginRequestModel, LoginDto>()
                .ForMember(loginModel => loginModel.Email,
                loginDto => loginDto.MapFrom(loginDto => RegexValues.EmailRegex.IsMatch(loginDto.UserNameOrEmail) ?
                loginDto.UserNameOrEmail : null))
                .ForMember(loginModel => loginModel.UserName
                , loginDto => loginDto.MapFrom(loginDto => !RegexValues.EmailRegex.IsMatch(loginDto.UserNameOrEmail) ?
                loginDto.UserNameOrEmail : null));

            // Manage Category usecase
            CreateMap<CategoryDto, CategoryResponseModel>();
            CreateMap<CategoryDto, CategoryResponseModelMin>();
            CreateMap<CategoryDto, Category>().ReverseMap();
            CreateMap<CategoryRequestModel, CategoryDto>();

            // Manage Material usecase
            CreateMap<MaterialDto, MaterialResponseModel>();
            CreateMap<MaterialDto, Material>().ReverseMap();
            CreateMap<MaterialRequestModel, MaterialDto>();

        }
    }
}