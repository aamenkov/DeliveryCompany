using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeliveryCompanyData.Entities;

namespace DeliveryCompanyDataAccessEF_xUnitTests
{
    internal static class RepositoryDepartmentHelper
    {
        internal static Department AddTestDepartment(string townName)
        {
            // IDBConnectionString testConnectionString = new DBConnectionString(CONNECTION_NAME);
            // IUnitOfWork unitOfWork = new UnitOfWork(testConnectionString);

            var department = new Department
            {
                Town = townName,
                ApplicationList = null
            };

            //  var newApplication = unitOfWork.Application.Add(application);

            return department;
        }

        internal static void DeleteTestDepartment(Department department)
        {

        }
    }
}
