using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryCompanyDataAccessEF.Interface
{
    /// <summary>
    /// Репозиторий для сущности системы. Доопределяется для каждной конкретной сущности.
    /// </summary>
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<List<TEntity>> GetAll();
        Task<TEntity> Get(object id);
        Task<TEntity> Add(TEntity entity);
        Task<TEntity> Update(TEntity entity);
        Task<TEntity> Delete(object id);
    }
}
