namespace ModelsConverter.Core.Converters
{
    public interface IConvertedModel<T, C> 
        where T : IConvertedProperty
        where C : ILanguageConverterConfiguration 
    {
        string Name { get; }
        string[]? Extends { get; }
        T[] Properties { get; }
        string Render(C configuration);
    }
}
