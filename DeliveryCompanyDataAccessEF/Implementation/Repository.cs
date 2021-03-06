using System.Collections.Generic;
using System.Threading.Tasks;
using DeliveryCompany.DataAccessEF.Context;
using DeliveryCompany.Domain.Interface;
using Microsoft.EntityFrameworkCore;

namespace DeliveryCompany.DataAccessEF.Implementation
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly MyAppContext Context;

        protected Repository(MyAppContext _context)
        {
            Context = _context;
        }

        public async Task<TEntity> Add(TEntity entity)
        {
            Context.Set<TEntity>().Add(entity);
            await Context.SaveChangesAsync();
            return entity;
        }

        public async Task Delete(object id)
        {
            var entity = await Context.Set<TEntity>().FindAsync(id);
            if (entity != null)
            {
                Context.Set<TEntity>().Remove(entity);
                await Context.SaveChangesAsync();
            }
        }

        public async Task<TEntity> Get(object id)
        {
            return await Context.Set<TEntity>().FindAsync(id);
        }

        public async Task<List<TEntity>> GetAll()
        {
            return await Context.Set<TEntity>().ToListAsync();
        }

        public async Task Update(TEntity entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
            await Context.SaveChangesAsync();
        }
    }
}
