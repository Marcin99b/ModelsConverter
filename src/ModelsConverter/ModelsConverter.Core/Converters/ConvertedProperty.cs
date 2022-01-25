namespace ModelsConverter.Core.Converters
{
    public class ConvertedProperty
    {
        public string TypeName { get; }
        public string Name { get; }

        public ConvertedProperty(string typeName, string name)
        {
            TypeName = typeName;
            Name = name;
        }
    }
}
