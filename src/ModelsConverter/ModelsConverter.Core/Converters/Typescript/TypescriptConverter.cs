using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ModelsConverter.Core.Converters.Typescript
{
    public class TypescriptConverter : ILanguageConverter<TypescriptModel, TypescriptProperty, TypescriptConfiguration>
    {
        public IConvertedModel Convert(Type type, ILanguageConverterConfiguration configuration)
            => this.Convert(type, configuration);

        public IConvertedModel<TypescriptProperty, TypescriptConfiguration> Convert(Type type, TypescriptConfiguration configuration)
        {
            var properties = type.GetProperties();
            var convertedProperties = this.ConvertProperties(properties, configuration);
            return new TypescriptModel(type.Name, null, convertedProperties.ToArray());
        }

        public IEnumerable<TypescriptProperty> ConvertProperties(PropertyInfo[] properties, TypescriptConfiguration configuration)
        {
            foreach (var property in properties)
            {
                var type = property.PropertyType.Name;
                var name = property.Name;
                var convertedTypeName = this.ConvertTypeName(type, configuration);
                yield return new TypescriptProperty(convertedTypeName, name);
            }
        }

        public string ConvertTypeName(string typeName, TypescriptConfiguration configuration)
        {
            if(configuration.TypeNames.ContainsKey(typeName))
            {
                return configuration.TypeNames[typeName];
            }
            return typeName;
        }
    }
}
