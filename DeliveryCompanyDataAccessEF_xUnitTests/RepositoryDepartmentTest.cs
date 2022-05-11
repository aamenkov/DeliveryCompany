using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeliveryCompanyData.Entities;
using DeliveryCompanyDataAccessEF.Implementation;
using DeliveryCompanyDataAccessEF.Interface;
using Xunit;

namespace DeliveryCompanyDataAccessEF_xUnitTests
{
    public class RepositoryDepartmentTest
    {
        /// <summary>
        /// Тест добавления нового отделения
        /// </summary>
        [Fact]
        public void DepartmentSaveNew_Test()
        {
            // подготовка к тесту
           // IDBConnectionString testConnectionString = new DBConnectionString(CONNECTION_NAME);
           // IUnitOfWork unitOfWork = new UnitOfWork(testConnectionString, TEST_ADMIN_LOGIN);

          //  _ = RepositoryDepartmentHelper.DeleteTestDepartment(Login, out _);

            // тест
            Department department = new()
            {
                Town = "Town_DepartmentSaveNew_Test"
            };

         //   var newDepartment = unitOfWork.Department.Add(department);


            // проверка теста
            Assert.NotEqual(new Guid(), department.DepartmentId);
        }
        /// <summary>
        /// Тест удаления отделения
        /// </summary>
        [Fact]
        public void DepartmentDelete_Test()
        {
            // подготовка к тесту
         //   IDBConnectionString testConnectionString = new DBConnectionString(CONNECTION_NAME);
         //   IUnitOfWork unitOfWork = new UnitOfWork(testConnectionString, TEST_ADMIN_LOGIN);

            var department = RepositoryDepartmentHelper.AddTestDepartment("Town_DepartmentDelete_Test");

            // тест
         //   var retVal = unitOfWork.Department.Delete(department);

            // проверка теста

        }
    }
}
