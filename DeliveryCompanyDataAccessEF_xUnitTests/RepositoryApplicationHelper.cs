using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeliveryCompanyData.Entities;
using DeliveryCompanyDataAccessEF.Context;
using DeliveryCompanyDataAccessEF.Implementation;
using DeliveryCompanyDataAccessEF.Interface;

namespace DeliveryCompanyDataAccessEF_xUnitTests
{
    internal static class RepositoryApplicationHelper
    {
        internal static Application AddTestApplication(string deliveryAddress)
        {
        //    var Context = new MyAppContext(options: options => options.UseSqlServer(ConfigurationManager.AppSettings.Get("DefaultConnection")));
        //    IUnitOfWork unitOfWork = new UnitOfWork(Context);

            var application = new Application
            {
                ReceivingAddress = "Test_ReceivingAddress",
                ReceivingTown = "Test_ReceivingTown",
                DeliveryAddress = deliveryAddress,
                DeliveryTown = "Test_DeliveryTown",
                Weight = 10,
                PhoneNumber = "79163749863",
                Status = "OK",
                Message = "OK"
            };

        //  var newApplication = unitOfWork.Application.Add(application);

            return application;
        }

        internal static void DeleteTestApplication(Application application)
        {

        }
    }
}
