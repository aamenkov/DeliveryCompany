using DeliveryCompany.Domain.Entities;

namespace DeliveryCompany.DataAccessEF_xUnitTests
{
    /// <summary>
    /// Вспомогательный класс для тестирования, для создания отделений.
    /// </summary>
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
