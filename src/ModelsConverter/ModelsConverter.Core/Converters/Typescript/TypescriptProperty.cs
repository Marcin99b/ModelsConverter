namespace ModelsConverter.Core.Converters.Typescript
{
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
}
