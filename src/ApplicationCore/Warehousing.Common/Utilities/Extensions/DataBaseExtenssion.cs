﻿using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Warehousing.Common.Utilities.Extensions
{
    public static class DataBaseExtenssion
    {
        public static void VerifyEntities<BaseType>(this ModelBuilder modelBuilder, params Assembly[] assemblies)
        {
            //Refilection
            IEnumerable<Type> types = assemblies.SelectMany(a => a.GetExportedTypes())
                .Where(c => c.IsClass && !c.IsAbstract && c.IsPublic && typeof(BaseType).IsAssignableFrom(c));

            foreach (var type in types)
                modelBuilder.Entity(type);
        }

        public static string DisplayNameAttribute(this Enum value, DisplayProperty property = DisplayProperty.Name)
        {
            var attribute = value.GetType().GetField(value.ToString())
                .GetCustomAttributes<DisplayAttribute>(false).FirstOrDefault();

            if (attribute == null)
                return value.ToString();

            var propValue = attribute.GetType().GetProperty(property.ToString()).GetValue(attribute, null);
            return propValue.ToString();
        }
    }
}
