namespace ModelsConverter.Core.Converters
{
    public interface IConvertedModel
    {
        string Name { get; }
        string[]? Extends { get; }
        IConvertedProperty[] Properties { get; }
        string Render(ILanguageConverterConfiguration configuration);
    }

    public interface IConvertedModel<T, C> : IConvertedModel
        where T : IConvertedProperty
        where C : ILanguageConverterConfiguration 
    {
        T[] Properties { get; }
        string Render(C configuration);
    }
}
