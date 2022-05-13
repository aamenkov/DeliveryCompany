using System.Collections.Generic;
using System.Threading.Tasks;

namespace DeliveryCompany.Domain.Interface
{
    /// <summary>
    /// Репозиторий для сущности системы. Доопределяется для каждной конкретной сущности.
    /// </summary>
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<List<TEntity>> GetAll();
        Task<TEntity> Get(object id);
        Task<TEntity> Add(TEntity entity);
        Task Update(TEntity entity);
        Task Delete(object id);
    }
}
