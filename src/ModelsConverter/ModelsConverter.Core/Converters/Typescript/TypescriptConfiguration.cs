namespace ModelsConverter.Core.Converters.Typescript
{
    public class TypescriptConfiguration : ILanguageConverterConfiguration
    {
        public int SpacesBeforeProperties { get; set; } = 2;
        public Dictionary<string, string> TypeNames { get; } = new () 
        {
            //todo add more types
            { typeof(string).Name, "string" },
            { typeof(long).Name, "number" },
            { typeof(ulong).Name, "number" },
            { typeof(int).Name, "number" },
            { typeof(uint).Name, "number" },
            { typeof(short).Name, "number" },
            { typeof(ushort).Name, "number" },
            { typeof(byte).Name, "number" },
            { typeof(float).Name, "number" },
            { typeof(double).Name, "number" },
            { typeof(decimal).Name, "number" },
            { typeof(bool).Name, "boolean" },
        };
    }
}
