using System;
using System.Collections.Generic;
using System.Linq;
using DeliveryCompanyData.Entities;

namespace DeliveryCompanyWebApi.Validation
{
    /// <summary>
    /// Вспомогательный класс для валидации и проверки входных данных
    /// </summary>
    public static class ApplicationValidation
    {
        private static readonly string[] _expectedStatuses = { "Новая", "Передано на выполнение", "Выполнена", "Отменена" };
        public static bool Check(Application application)
        {
            var isStatusCorrect = (_expectedStatuses.Any(status => status == application.Status) || (application.Status == null));

            var isProfileCorrect = (application.Weight >= 0) && (application.Height >= 0) && (application.Length >= 0)
                                    && (application.Width >= 0) && (application.Volume >= 0);

            return isStatusCorrect && isProfileCorrect;
        }

        public static bool CheckList(List<Application> applications)
        {
            if (applications == null)
                return true;

            return applications.All(application => Check(application)); ;
        }
    }
}
