using ModelsConverter.Core.Extensions;
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
            var spaces = string.Empty
                .AddSpaces(configuration.SpacesBeforeProperties);

            var result = new StringBuilder()
                .AppendLine(this.RenderClassLine(this.Name, this.Extends))
                .AppendLineForeach(this.Properties, x => $"{spaces}{x.Render()}")
                .AppendLine("}")
                .ToString()
                .TrimSpacesAndNewlines();

            return result;
        }

        private string RenderClassLine(string name, string[]? extends)
        {
            var result = $"export class {name}";
            if (extends != null)
            {
                result += $"extends {string.Join(", ", extends)}";
            }
            result += " {";
            return result;
        }
    }
}
