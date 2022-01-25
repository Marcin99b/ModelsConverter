using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ModelsConverter.Core.Converters.Typescript
{
    public class TypescriptConverter : ILanguageConverter
    {
        public ConvertedModel Convert(Type type)
        {
            var properties = type.GetProperties();
            var convertedProperties = this.ConvertProperties(properties);
            return new ConvertedModel(type.Name, null, convertedProperties.ToArray());
        }

        public string Render(ConvertedModel model)
        {
            var spacesConfig = 2;

            var sb = new StringBuilder();
            var classLine = "export class " + model.Name;
            if(model.Extends != null)
            {
                classLine += "extends " + string.Join(", ", model.Extends);
            }
            classLine += " {";
            sb.AppendLine(classLine);

            var spaces = string.Empty;
            for (var i = 0; i < spacesConfig; i++)
            {
                spaces += " ";
            }
            foreach (var property in model.Properties)
            {
                var propertyLine = $"{spaces}{property.Name}: {property.TypeName};";
                sb.AppendLine(propertyLine);
            }

            sb.AppendLine("}");

            return sb.ToString().Trim(" \r\n".ToCharArray());
        }

        public IEnumerable<ConvertedProperty> ConvertProperties(PropertyInfo[] properties)
        {
            foreach (var property in properties)
            {
                //todo check if type is in input types
                var type = property.PropertyType.Name;
                var name = property.Name;
                var convertedTypeName = this.ConvertTypeName(type);
                yield return new ConvertedProperty(convertedTypeName, name);
            }
        }

        public string ConvertTypeName(string typeName)
        {
            //todo optimize
            var stringType = typeof(string).Name;
            var longType = typeof(long).Name;
            var intType = typeof(int).Name;
            var shortType = typeof(short).Name;
            var floatType = typeof(float).Name;
            var boolType = typeof(bool).Name;
            if(typeName == stringType)
                return "string";
            if(typeName == longType)
                return "number";
            if (typeName == intType)
                return "number";
            if (typeName == shortType)
                return "number";
            if (typeName == floatType)
                return "number";
            if (typeName == boolType)
                return "boolean";
            return typeName;
        }
    }
}
