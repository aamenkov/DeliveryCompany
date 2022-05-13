using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DeliveryCompany.DataAccessEF.Context;
using DeliveryCompany.Domain.Entities;
using DeliveryCompany.Domain.Interface;

namespace DeliveryCompany.DataAccessEF.Implementation
{
    public class DepartmentRepository : Repository<Department>, IDepartmentRepository
    {
        public DepartmentRepository(MyAppContext context) : base(context) { }

        public async Task<List<Application>> GetApplications(int id)
        {
            var list = Context
                .Application
                .Where(
                    application => application.DepartmentId == id).ToList();
               // .OrderBy(x => x.Status).ToList();

            return list;
        }
    }
}
