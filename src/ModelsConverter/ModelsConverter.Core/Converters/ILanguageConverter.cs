namespace ModelsConverter.Core.Converters
{
    public interface ILanguageConverter<T, P, C> 
        where T : IConvertedModel<P, C>
        where P : IConvertedProperty
        where C : ILanguageConverterConfiguration
    {
        public IConvertedModel<P, C> Convert(Type type);
    }
}
