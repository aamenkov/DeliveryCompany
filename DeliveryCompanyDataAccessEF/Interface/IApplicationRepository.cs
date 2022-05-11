using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeliveryCompanyData.Entities;

namespace DeliveryCompanyDataAccessEF.Interface
{
    public interface IApplicationRepository: IRepository<Application>
    {
    }
}
