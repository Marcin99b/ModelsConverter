namespace ModelsConverter.Core.Converters.Typescript
{
    public class TypescriptProperty : ConvertedProperty
    {
        public TypescriptProperty(string typeName, string propertyName) : base(typeName, propertyName)
        {
        }

        public override string Render() => $"{this.PropertyName}: {this.TypeName};";
    }
}
