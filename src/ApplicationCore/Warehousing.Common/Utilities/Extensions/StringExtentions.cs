using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Warehousing.Common.Utilities.Extensions
{
    public static class StringExtentions
    {
        public static string En2Fa(this string str)
        {
            return str.Replace("0", "۰")
                .Replace("1", "۱")
                .Replace("2", "۲")
                .Replace("3", "۳")
                .Replace("4", "۴")
                .Replace("5", "۵")
                .Replace("6", "۶")
                .Replace("7", "۷")
                .Replace("8", "۸")
                .Replace("9", "۹");
        }

        public static string Fa2En(this string str)
        {
            return str.Replace("۰", "0")
                .Replace("۱", "1")
                .Replace("۲", "2")
                .Replace("۳", "3")
                .Replace("۴", "4")
                .Replace("۵", "5")
                .Replace("۶", "6")
                .Replace("۷", "7")
                .Replace("۸", "8")
                .Replace("۹", "9")
                //iphone numeric
                .Replace("٠", "0")
                .Replace("١", "1")
                .Replace("٢", "2")
                .Replace("٣", "3")
                .Replace("٤", "4")
                .Replace("٥", "5")
                .Replace("٦", "6")
                .Replace("٧", "7")
                .Replace("٨", "8")
                .Replace("٩", "9");
        }

        public static string FixPersianChars(this string str)
        {
            return str.Replace("ﮎ", "ک")
                .Replace("ﮏ", "ک")
                .Replace("ﮐ", "ک")
                .Replace("ﮑ", "ک")
                .Replace("ك", "ک")
                .Replace("ي", "ی")
                .Replace("‌ ", "")
                .Replace("ھ", "ه");
        }

        public static string PersianToArabicWithoutWhiteSpace(this string str)
        {
            return str
                .Replace("ک", "ك")
                .Replace("ی", "ي")
                .Replace(" ", String.Empty);
        }

        public static string CleanString(this string str)
        {
            return str.Trim().FixPersianChars().Fa2En();
        }

        public static string NullIfEmpty(this string str)
        {
            return str?.Length == 0 ? null : str;
        }
        public static string GetDisplayValue(this Enum enumValue)
        {
            string displayName;

            displayName = enumValue.GetType()
                                   .GetMember(enumValue.ToString())
                                   .FirstOrDefault()
                                   .GetCustomAttribute<DisplayAttribute>()?
                                   .GetName();

            if (string.IsNullOrEmpty(displayName))
                displayName = enumValue.ToString().Trim();

            return displayName;
        }
    }
}
