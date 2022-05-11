using System;
using System.Collections.Generic;
using System.Text;

namespace DeliveryCompanyDataAccessEF.Interface
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
