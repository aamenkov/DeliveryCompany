using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeliveryCompanyData.Entities;

namespace DeliveryCompanyDataAccessEF.Interface
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
