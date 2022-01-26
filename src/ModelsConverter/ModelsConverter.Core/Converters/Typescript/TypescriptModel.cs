using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsConverter.Core.Converters.Typescript
{
    public class TypescriptModel : IConvertedModel<TypescriptProperty, TypescriptConfiguration>
    {
        public string Name { get; }
        public string[]? Extends { get; }
        public TypescriptProperty[] Properties { get; }

        public TypescriptModel(string name, string[]? extends, TypescriptProperty[] properties)
        {
            this.Name = name;
            this.Extends = extends;
            this.Properties = properties;
        }

        public string Render(TypescriptConfiguration configuration)
        {
            var sb = new StringBuilder();
            var classLine = "export class " + this.Name;
            if (this.Extends != null)
            {
                classLine += "extends " + string.Join(", ", this.Extends);
            }
            classLine += " {";
            sb.AppendLine(classLine);

            var spaces = string.Empty;
            for (var i = 0; i < configuration.SpacesBeforeProperties; i++)
            {
                spaces += " ";
            }
            foreach (var property in this.Properties)
            {
                var propertyLine = spaces + property.Render();
                sb.AppendLine(propertyLine);
            }

            sb.AppendLine("}");

            return sb.ToString().Trim(" \r\n".ToCharArray());
        }
    }

    public class TypescriptProperty : IConvertedProperty
    {
        public string TypeName { get; }
        public string PropertyName { get; }

        public TypescriptProperty(string typeName, string propertyName)
        {
            this.TypeName = typeName;
            this.PropertyName = propertyName;
        }

        public string Render() => $"{this.PropertyName}: {this.TypeName};";
    }

    public class TypescriptConfiguration : ILanguageConverterConfiguration
    {
        public int SpacesBeforeProperties { get; set; } = 2;
    }
}
