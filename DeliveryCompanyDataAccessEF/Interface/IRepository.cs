using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DeliveryCompanyDataAccessEF.Interface
{
    /// <summary>
    /// Репозиторий для сущности системы. Доопределяется для каждной конкретной сущности.
    /// </summary>
    public interface IRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// Получить объект по идентификатору
        /// </summary>
        public TEntity GetById(object id);

        /// <summary>
        /// Получить все объекты
        /// </summary>
        public IEnumerable<TEntity> GetAll();

        /// <summary>
        /// Найти объекты по заданному условию
        /// </summary>
        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// Добавить новый экземляр сущности
        /// </summary>
        public void Add(TEntity entity);

        /// <summary>
        /// Добавить нескольно сущностей
        /// </summary>
        public void AddRange(IEnumerable<TEntity> entities);

        /// <summary>
        /// Удаление сущности
        /// </summary>
        public void Remove(TEntity entity);

        /// <summary>
        /// Удаление сущности по Id
        /// </summary>
        public void Remove(object id);

        /// <summary>
        /// Удаление сущностей по списку
        /// </summary>
        public void RemoveRange(IEnumerable<TEntity> entities);

    }
}
