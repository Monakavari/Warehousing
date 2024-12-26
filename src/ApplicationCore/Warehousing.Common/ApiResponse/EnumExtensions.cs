using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Warehousing.Common
{
    public static class EnumExtensions
    {
        public static string ToDisplay(this Enum value, DisplayProperty property = DisplayProperty.Name)
        {
            if (value == null)
            {
                throw new ArgumentNullException("Argument value is NULL");
            }

            DisplayAttribute displayAttribute = value.GetType().GetField(value.ToString()).GetCustomAttributes<DisplayAttribute>(inherit: false)
                .FirstOrDefault();
            if (displayAttribute == null)
            {
                return value.ToString();
            }

            return displayAttribute.GetType().GetProperty(property.ToString())!.GetValue(displayAttribute, null)!.ToString();
        }
    }

}
