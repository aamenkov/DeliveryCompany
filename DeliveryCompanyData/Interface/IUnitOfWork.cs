using System;

namespace DeliveryCompany.Domain.Interface
{
    /// <summary>
    /// Используется при выполнении операций над объектами
    /// </summary>
    public interface IUnitOfWork : IDisposable { 
        public IDepartmentRepository Department{ get; } 
        public IApplicationRepository Application { get; }
        int Save();
    }
}
