using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using DeliveryCompanyDataAccessEF.Interface;
using DeliveryCompanyDataAccessEF.Context;
using Microsoft.EntityFrameworkCore;

namespace DeliveryCompanyDataAccessEF.Implementation
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly MyAppContext Context;

        protected Repository(MyAppContext _context)
        {
            Context = _context;
        }

        //public TEntity GetById(object id)
        //{
        //    return Context.Set<TEntity>().Find(id);
        //}

        //public IEnumerable<TEntity> GetAll()
        //{
        //    return Context.Set<TEntity>().ToList();
        //}

        //public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> expression)
        //{
        //    return Context.Set<TEntity>().Where(expression);
        //}

        //public void Add(TEntity entity)
        //{
        //    Context.Set<TEntity>().Add(entity);
        //}

        //public void AddRange(IEnumerable<TEntity> entities)
        //{
        //    Context.Set<TEntity>().AddRange(entities);
        //}

        //public void Remove(TEntity entity)
        //{
        //    Context.Set<TEntity>().Remove(entity);
        //}

        //public void Remove(object id)
        //{
        //    throw new NotImplementedException();
        //}

        //public void RemoveRange(IEnumerable<TEntity> entities)
        //{
        //    Context.Set<TEntity>().RemoveRange(entities);
        //}

        public async Task<TEntity> Add(TEntity entity)
        {
            Context.Set<TEntity>().Add(entity);
            await Context.SaveChangesAsync();
            return entity;
        }

        public async Task<TEntity> Delete(object id)
        {
            var entity = await Context.Set<TEntity>().FindAsync(id);
            if (entity == null)
            {
                return null;
            }

            Context.Set<TEntity>().Remove(entity);
            await Context.SaveChangesAsync();

            return entity;
        }

        public async Task<TEntity> Get(object id)
        {
            return await Context.Set<TEntity>().FindAsync(id);
        }

        public async Task<List<TEntity>> GetAll()
        {
            return await Context.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity> Update(TEntity entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
            await Context.SaveChangesAsync();
            return entity;
        }
    }
}
