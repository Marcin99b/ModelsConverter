namespace ModelsConverter.Core.Converters
{
    public interface ILanguageConverter
    {
        public ConvertedModel Convert(Type type);
    }
}
