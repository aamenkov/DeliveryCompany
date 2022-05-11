using System;
using System.Collections.Generic;
using System.Linq;
using DeliveryCompanyData.Entities;

namespace DeliveryCompanyWebApi.Validation
{
    public static class Validation
    {
        public static bool CheckApplication(Application application)
        {
            if (application.Weight > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool CheckApplicationList(List<Application> list)
        {
            var check = true;
            foreach (var variable in list.Where(variable => !CheckApplication(variable)))
            {
                check = false;
            }

            if (list.Count > 8)
                check = false;

            return check;
        }
    }
}
