namespace ModelsConverter.Core.Converters
{
    public interface ILanguageConverter
    {
        public IConvertedModel Convert(Type type, ILanguageConverterConfiguration configuration);
    }

    public interface ILanguageConverter<T, P, C> : ILanguageConverter
        where T : IConvertedModel<P, C>
        where P : IConvertedProperty
        where C : ILanguageConverterConfiguration
    {
        public IConvertedModel<P, C> Convert(Type type, C configuration);
    }
}
