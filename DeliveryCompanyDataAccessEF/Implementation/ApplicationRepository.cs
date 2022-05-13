using DeliveryCompany.DataAccessEF.Context;
using DeliveryCompany.Domain.Entities;
using DeliveryCompany.Domain.Interface;

namespace DeliveryCompany.DataAccessEF.Implementation
{
    public class ApplicationRepository : Repository<Application>, IApplicationRepository
    {
        public ApplicationRepository(MyAppContext context) : base(context) { }
    }
}
