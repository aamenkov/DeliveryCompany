using System.Collections.Generic;
using System.Threading.Tasks;
using DeliveryCompany.Domain.Entities;


namespace DeliveryCompany.Domain.Interface
{
    public interface IDepartmentRepository : IRepository<Department>
    {
        /// <summary>
        /// Получить все заявки по отделению департамента.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<List<Application>> GetApplications(int id);
    }

}
