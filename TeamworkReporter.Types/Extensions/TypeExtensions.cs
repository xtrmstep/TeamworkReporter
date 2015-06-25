using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TeamworkReporter.Types.Extensions
{
    public static class TypeExtensions
    {
        public static PropertyInfo[] GetKeyProperties(this Type type)
        {
            if (type == null) return null;

            var propertiesByAttr = type.GetProperties()
                .Where(p => p.GetCustomAttribute<KeyAttribute>() != null);

            var propertiesByMatch = type.GetProperties()
                .Where(p => p.Name.ToUpper().Contains("ID") && propertiesByAttr.Any(pa => pa.Name == p.Name) == false);

            var properties = propertiesByAttr.Concat(propertiesByMatch).ToArray();

            return properties;
        }
    }
}
