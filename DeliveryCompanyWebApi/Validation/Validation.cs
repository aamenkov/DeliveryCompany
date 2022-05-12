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
            if ((application.Weight >= 0) && (application.Height >= 0) && (application.Length >= 0) && 
                (application.Width >= 0) && (application.Volume >= 0))
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

            if (list == null)
                return true;

            foreach (var variable in list.Where(variable => !CheckApplication(variable)))
            {
                check = false;
            }

            return check;
        }
    }
}
