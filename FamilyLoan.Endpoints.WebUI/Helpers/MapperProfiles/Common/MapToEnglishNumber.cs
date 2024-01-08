using System;

namespace FamilyLoan.Endpoints.WebUI.Helpers.MapperProfiles.Common
{
    public static class MapToEnglishNumber
    {
        public static DateTime PersianMap(string data)
            {
            
            var EnglishNumbers = "";
            for(int i = 0; i < data.Length; i++)
            {
              if(char.IsDigit(data[i]))
                {
                    EnglishNumbers += char.GetNumericValue(data, i);
                }
                else
                {
                    EnglishNumbers += data[i].ToString();
                }
            }
           var num = Convert.ToDateTime(EnglishNumbers);
            return num;
        }
    }
}
