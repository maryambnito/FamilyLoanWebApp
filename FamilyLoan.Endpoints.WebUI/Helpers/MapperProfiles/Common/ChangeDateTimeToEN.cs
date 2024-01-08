using System;

namespace FamilyLoan.Endpoints.WebUI.Helpers.MapperProfiles.Common
{
    public static class ChangeDateTimeExtention
    {

        public static string ChangeDateToEN(this string date)
        {
            if (date == null)
            {
                date = default;


            }
            else
            {
                return date.
                    Replace("۰", "0").
                    Replace("۱", "1").
                    Replace("۲", "2").
                    Replace("۳", "3").
                    Replace("۴", "4").
                    Replace("۵", "5").
                    Replace("۶", "6").
                    Replace("۷", "7").
                    Replace("۸", "8").
                    Replace("۹", "9");
                var fromdate = MapToEnglishNumber.PersianMap(date);
                PersianDateTime fromdatetime = fromdate.ToPersianDateTime();
                date = Convert.ToString(fromdatetime.ToDateTime());


            }
            return date;
        }
        public static DateTime ChangeToDateTime(this string date)
        {
            if (string.IsNullOrEmpty(date))
            {
                return default;

            }
            else
            {
                return PersianDateTime.Parse(date).ToDateTime();


            }
        }

        public static string ChangeToPersianDateTime(this DateTime date)
        {
            if (date == default)
            {
                return default;

            }
            else
            {
                return date.ToPersianDateString();


            }
        }

    }
}
