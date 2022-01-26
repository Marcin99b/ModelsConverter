namespace ModelsConverter.Core.Converters
{
    public interface IConvertedProperty
    {
        string TypeName { get; }
        string PropertyName { get; }
        string Render();
    }

    public abstract class ConvertedProperty : IConvertedProperty
    {
        public string TypeName { get; }

        public string PropertyName { get; }

        protected ConvertedProperty(string typeName, string propertyName)
        {
            this.TypeName = typeName;
            this.PropertyName = propertyName;
        }

        public abstract string Render();
    }
}
