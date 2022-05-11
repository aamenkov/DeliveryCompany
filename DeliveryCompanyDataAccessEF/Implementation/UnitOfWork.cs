using DeliveryCompanyDataAccessEF.Interface;
using NLog;
using System;
using DeliveryCompanyDataAccessEF.Context;

namespace DeliveryCompanyDataAccessEF.Implementation
{
    public class UnitOfWork : IUnitOfWork
    {
        private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
        private readonly MyAppContext _context;

      //  private IRepositoryUsers _users;

      public UnitOfWork(MyAppContext context)
      {
          this._context = context;
          Department = new DepartmentRepository(this._context);
          Application = new ApplicationRepository(this._context);
      }

        // public IRepositoryUsers Users => _users;
        public IDepartmentRepository Department{ get; private set;}
        public IApplicationRepository Application{ get; private set;}
    
        public void Dispose()
        {
            _context.Dispose();
        }

        public int Save()
        {
            return _context.SaveChanges();
        }
    }
}
