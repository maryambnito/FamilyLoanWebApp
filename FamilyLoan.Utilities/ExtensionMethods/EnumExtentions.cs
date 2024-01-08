using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace FamilyLoan.Utilities.ExtensionMethods
{

    public static class EnumExtentions
    {
        public static Dictionary<T, string> ToDictionary<T>(this T t) where T : Enum
        {
            Type enumType = typeof(T);

            // Can't use type constraints on value types, so have to do check like this
            if (enumType.BaseType != typeof(Enum))
                throw new ArgumentException("نوع جنریک ورودی حتما باید Enum باشد");

            Array enumValArray = Enum.GetValues(enumType);

            Dictionary<T, string> dic = new Dictionary<T, string>(enumValArray.Length);

            foreach (int val in enumValArray)
            {
                var e = (T)Enum.Parse(enumType, val.ToString());
                dic.Add(e, GetDescription(e));
            }

            return dic;
        }
        public static Dictionary<T, string> ToDictionary<T>() where T : Enum
        {
            Type enumType = typeof(T);

            // Can't use type constraints on value types, so have to do check like this
            if (enumType.BaseType != typeof(Enum))
                throw new ArgumentException("نوع جنریک ورودی حتما باید Enum باشد");

            Array enumValArray = Enum.GetValues(enumType);

            Dictionary<T, string> dic = new Dictionary<T, string>(enumValArray.Length);

            foreach (int val in enumValArray)
            {
                var e = (T)Enum.Parse(enumType, val.ToString());
                dic.Add(e, GetDescription(e));
            }

            return dic;
        }
        public static List<T> ToList<T>() where T : Enum
        {
            Type enumType = typeof(T);

            // Can't use type constraints on value types, so have to do check like this
            if (enumType.BaseType != typeof(Enum))
                throw new ArgumentException("نوع جنریک ورودی حتما باید Enum باشد");

            Array enumValArray = Enum.GetValues(enumType);

            List<T> enumValList = new List<T>(enumValArray.Length);

            foreach (int val in enumValArray)
            {
                enumValList.Add((T)Enum.Parse(enumType, val.ToString()));
            }

            return enumValList;
        }
        public static string GetEnumDescription(Enum value)
        {
            if (value.ToString() == "0")
            {
                return "بدون مقدار";
            }
            FieldInfo fi = value.GetType().GetField(value.ToString());

            DescriptionAttribute[] attributes = fi.GetCustomAttributes(typeof(DescriptionAttribute), false) as DescriptionAttribute[];

            if (attributes != null && attributes.Any())
            {
                return attributes.First().Description;
            }

            return value.ToString();
        }
        public static string GetDescription<T>(this T t) where T : Enum
        {
            if (t.ToString() == "0")
            {
                return "بدون مقدار";
            }
            FieldInfo fi = t.GetType().GetField(t.ToString());

            DescriptionAttribute[] attributes = fi.GetCustomAttributes(typeof(DescriptionAttribute), false) as DescriptionAttribute[];

            if (attributes != null && attributes.Any())
            {
                return attributes.First().Description;
            }

            return t.ToString();
        }
        public static IEnumerable<T> GetEnumValues<T>(this T input) where T : struct
        {
            if (!typeof(T).IsEnum)
                throw new NotSupportedException();

            return Enum.GetValues(input.GetType()).Cast<T>();
        }

        public static IEnumerable<T> GetEnumFlags<T>(this T input) where T : struct
        {
            if (!typeof(T).IsEnum)
                throw new NotSupportedException();

            foreach (var value in Enum.GetValues(input.GetType()))
                if ((input as Enum).HasFlag(value as Enum))
                    yield return (T)value;
        }


        public static T ParseEnum<T>(string value)
        {
            return (T)Enum.Parse(typeof(T), value, true);
        }

        public static T ToEnum<T>(this string value, T defaultValue) where T : struct
        {
            if (string.IsNullOrEmpty(value))
            {
                return defaultValue;
            }

            T result;
            return Enum.TryParse<T>(value, true, out result) ? result : defaultValue;
        }

        public static IEnumerable<T> EnumToList<T>()
        {
            return Enum.GetValues(typeof(T)).Cast<T>();
        }
    }


}