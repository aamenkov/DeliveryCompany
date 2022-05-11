﻿using DeliveryCompanyDataAccessEF.Interface;
using NLog;
using System;
using DeliveryCompanyDataAccessEF.Context;

namespace DeliveryCompanyDataAccessEF.Implementation
{
    public class UnitOfWork : IUnitOfWork
    {
        private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
        private readonly MyAppContext _context;

        public UnitOfWork(MyAppContext context)
      {
          this._context = context;
          Department = new DepartmentRepository(this._context);
          Application = new ApplicationRepository(this._context);
      }

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
