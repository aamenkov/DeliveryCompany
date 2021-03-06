using DeliveryCompany.Domain.Entities;
using Xunit;

namespace DeliveryCompany.DataAccessEF_xUnitTests
{
    /// <summary>
    /// Класс для тестирования репозитория отделений.
    /// </summary>
    public class RepositoryDepartmentTest
    {
        /// <summary>
        /// Тест добавления нового отделения
        /// </summary>
        [Fact]
        public void DepartmentSaveNew_Test()
        {
            // подготовка к тесту

            //  _ = RepositoryDepartmentHelper.DeleteTestDepartment("Name_DepartmentSaveNew_Test", out _);

            // тест
            Department department = new()
            {
                Name = "Name_DepartmentSaveNew_Test"
            };

            //   var newDepartment = unitOfWork.Department.Add(department);


            // проверка теста
            //   Assert.NotEqual(new Guid(), department.DepartmentId);
        }
        /// <summary>
        /// Тест удаления отделения
        /// </summary>
        [Fact]
        public void DepartmentDelete_Test()
        {
            // подготовка к тесту

            var department = RepositoryDepartmentHelper.AddTestDepartment("Name_DepartmentDelete_Test");

            // тест
            //   var retVal = unitOfWork.Department.Delete(department);

            // проверка теста

        }
    }
}
