namespace ModelsConverter.Core.Converters
{
    public class ConvertedModel
    {
        public string Name { get; }
        public string[]? Extends { get; }
        public ConvertedProperty[] Properties { get; }

        public ConvertedModel(string name, string[]? extends, ConvertedProperty[] properties)
        {
            Name = name;
            Extends = extends;
            Properties = properties;
        }
    }
}
