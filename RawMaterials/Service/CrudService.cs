using AutoMapper;
using RawMaterials.ExceptionsManagement.Exceptions.EntityNotExisted;
using RawMaterials.Repository.PagingAndSorting;
using RawMaterials.Service.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace RawMaterials.Service
{
    public abstract class CrudService<ModelDto, IBusinessRepo, ModelEntity, EntityNotExistedExceptionType> : ICrudService<ModelDto>
        where IBusinessRepo : IPagingAndSorting<ModelEntity>
        where ModelDto : class
        where ModelEntity : class
        where EntityNotExistedExceptionType : EntityNotExistedException, new()
    {

        protected IBusinessRepo _businessRepo;
        protected IMapper _mapper;

        public CrudService(IBusinessRepo businessRepo, IMapper mapper)
        {
            _businessRepo = businessRepo;
            _mapper = mapper;
        }
        public async Task<ModelDto> Create(ModelDto modelDto)
        {
            await CheckCreateRules(modelDto);

            var modelEntity = _mapper.Map<ModelEntity>(modelDto);
            var modelEntityResult = await _businessRepo.Add(modelEntity);

            return _mapper.Map<ModelDto>(modelEntityResult);
        }


        public async Task<ModelDto> Delete(int id)
        {
            // TODO: handle materials that in this category

            // if entity is not existed, throw exception
            var modelEntity = await _businessRepo.GetById(id);
            if (modelEntity == null)
                throw new EntityNotExistedExceptionType();

            await CheckDeleteRules(id);

            return _mapper.Map<ModelDto>(await _businessRepo.Remove(modelEntity));
        }


        public async Task<IEnumerable<ModelDto>> GetAll(PageAble pageable)
        {
            var CheckGet = CheckGetRules();
            if (CheckGet != null)
                return await GetWhere(CheckGet);
            else
                return _mapper.Map<ModelEntity[], IEnumerable<ModelDto>>((await _businessRepo.GetAll(pageable)).ToArray());
        }

        public async Task<ModelDto> GetSignle(int id)
        {
            if (!await IsExisted(id))
                throw new EntityNotExistedExceptionType();

            var CheckGet = CheckGetRules();
            if (CheckGet != null)
                return (await GetWhere(CheckGet)).First();
            else
                return _mapper.Map<ModelDto>(await _businessRepo.GetById(id));
        }

        public async Task<ModelDto> Update(int id, ModelDto modelDto)
        {
            if (!await IsExisted(id))
                throw new EntityNotExistedExceptionType();

            await CheckUpdateRules(id, modelDto);

            modelDto = PutId(modelDto, id);

            var modelEntity = _mapper.Map<ModelEntity>(modelDto);

            var modelEntityRes = await _businessRepo.Update(modelEntity);

            return _mapper.Map<ModelDto>(modelEntityRes);
        }

        private async Task<bool> IsExisted(long id)
        {
            return await _businessRepo.GetById(id) != null;
        }

        public async Task<IEnumerable<ModelDto>> GetWhere(Expression<Func<ModelEntity, bool>> predicate)
        {

            // var ex =   _mapper.Map<ModelEntity>(predicate.Body);

            //   var param = Expression.Parameter(typeof(ModelEntity));
            // var x = _mapper.Map<ModelEntity>(predicate.Parameters[0]);
            //  var body = new Visitor<ModelEntity>(param).Visit(predicate.Body);


            //   var x = ExpressionTransformer<ModelDto, ModelEntity>.Tranform(predicate);

            // Expression<Func<ModelEntity, bool>> lambda = Expression.Lambda<Func<ModelEntity, bool>>(predicate.Body, param);

            /*   var ex = Expression.Lambda<Func<ModelEntity, bool>>(
                         predicate.Body.Replace(predicate.Parameters[0], param), param);*/

            //Console.WriteLine("Type: {0}", ex.Body.Type);


            /* var p = Expression.Parameter(typeof(object));
             var e2 = Expression.Lambda<Func<ModelEntity, bool>>(
                 Expression.Invoke(predicate, Expression.Convert(p, typeof(ModelEntity))), p);
            */

            return _mapper.Map<ModelEntity[], IEnumerable<ModelDto>>((await _businessRepo.GetWhere(predicate)).ToArray());
        }


        protected abstract ModelDto PutId(ModelDto modelDto, int id);
        internal abstract Task CheckCreateRules(ModelDto modelDto);
        internal abstract Expression<Func<ModelEntity, bool>> CheckGetRules();
        internal abstract Task CheckUpdateRules(int id, ModelDto modelDto);
        internal abstract Task CheckDeleteRules(int id);

        public Task<IEnumerable<ModelDto>> GetWhere(Expression<Func<ModelDto, bool>> predicate)
            => throw new NotImplementedException();
        
    }
}
