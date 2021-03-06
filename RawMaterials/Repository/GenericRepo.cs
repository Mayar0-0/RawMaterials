﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using RawMaterials.Data;


using RawMaterials.Models.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace RawMaterials.Repository
{
    public class GenericRepo<T> : IGenericRepo<T> where T : class
    {

        protected RawMaterialsContext Context;

        public GenericRepo(RawMaterialsContext context)
        {
            Context = context;

        }

        public Task<T> FirstOrDefault(Expression<Func<T, bool>> predicate)
            => Context.Set<T>().FirstOrDefaultAsync(predicate);

        public async Task<T> Add(T entity)
        {
            // await Context.AddAsync(entity);
            await Context.Set<T>().AddAsync(entity);            

            await Context.SaveChangesAsync();
            return entity;
        }

        public async Task<T> Update(T entity)
        {
            Context.Entry(entity).State = EntityState.Modified;       
            await Context.SaveChangesAsync();
            return entity;
        }

        public async Task<T> Remove(T entity)
        {
            Context.Set<T>().Remove(entity);
            await Context.SaveChangesAsync();
            return entity;
        }

        public IQueryable<T> GetAll()
        {
            return Context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetWhere(Expression<Func<T, bool>> predicate)
        {
            return await Context.Set<T>().Where(predicate).ToListAsync();
        }

        public Task<int> CountAll() => Context.Set<T>().CountAsync();

        public Task<int> CountWhere(Expression<Func<T, bool>> predicate)
            => Context.Set<T>().CountAsync(predicate);

        public async Task<T> GetById(long id)
        {
            var entity = await Context.Set<T>().FindAsync(id);
            if (entity != null)
                Context.Entry(entity).State = EntityState.Detached;
            return entity;
        }

       public async  Task<bool> IsExisted(long id)
        {
            var entity = await Context.Set<T>().FindAsync(id);
            return entity != null;
        }

    }

}

