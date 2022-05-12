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
        internal static Department AddTestDepartment(string name)
        {

            var department = new Department
            {
                Name = name,
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
