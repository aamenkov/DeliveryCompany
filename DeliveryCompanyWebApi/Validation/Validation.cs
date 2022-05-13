using System;
using System.Collections.Generic;
using System.Linq;
using DeliveryCompanyData.Entities;

namespace DeliveryCompanyWebApi.Validation
{
    /// <summary>
    /// Вспомогательный класс для валидации и проверки входных данных
    /// </summary>
    public static class Validation
    {
        private static readonly string[] _expectedInput = { "Новая", "Передано на выполнение", "Выполнена", "Отменена" };
        public static bool CheckApplication(Application application)
        {
            return ((Array.IndexOf(_expectedInput, application.Status) >= 0) || (application.Status == null))
                   && (application.Weight >= 0) && (application.Height >= 0) && (application.Length >= 0) 
                   && (application.Width >= 0) && (application.Volume >= 0);
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
