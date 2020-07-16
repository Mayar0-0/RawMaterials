using AutoMapper;
using RawMaterials.ExceptionsManagement.Exceptions.EntityNotExisted;
using RawMaterials.ExceptionsManagement.Exceptions.EntityPropExisted;
using RawMaterials.Models.Dto;
using RawMaterials.Models.Entities;
using RawMaterials.Repository.IRepository;
using RawMaterials.Service.IService;
using System;
using System.Threading.Tasks;

namespace RawMaterials.Service
{
    public class MaterialService : CrudService<MaterialDto, IMaterialRepo, Material, MaterialNotExistedException>,  IMaterialService
    {
        public MaterialService(IMaterialRepo materialRepo, IMapper mapper) : base(materialRepo, mapper) { }

        protected override MaterialDto PutId(MaterialDto materialDto, int id)
        {
            materialDto.Id = id;
            return materialDto;
        }

        internal override async Task CheckCreateRules(MaterialDto materialDto)
        {
            if (await NameIsExisted(materialDto.Name))
                throw new MaterialNameExistedException(materialDto.Name);
        }

        internal override Task CheckDeleteRules(int id)
        {
            return Task.CompletedTask;
        }

        internal override async Task CheckUpdateRules(int id, MaterialDto materialDto)
        {
            if (await MaterialNameChanged(id, materialDto.Name))
                if (await NameIsExisted(materialDto.Name))
                    throw new MaterialNameExistedException(materialDto.Name);
        }

        private async Task<bool> MaterialNameChanged(long id, string name)
        {
            return (await _businessRepo.GetById(id)).Name != name;
        }

        private async Task<bool> NameIsExisted(string name)
        {
            return await _businessRepo.IsExistedByName(name);
        }
    }
}
