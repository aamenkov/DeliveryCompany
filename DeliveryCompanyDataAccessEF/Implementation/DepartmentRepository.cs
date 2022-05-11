using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeliveryCompanyData.Entities;
using DeliveryCompanyDataAccessEF.Interface;
using DeliveryCompanyDataAccessEF.Context;

namespace DeliveryCompanyDataAccessEF.Implementation
{
    public class DepartmentRepository : Repository<Department>, IDepartmentRepository
    {
        public DepartmentRepository(MyAppContext context) : base(context) { }
    }
}
