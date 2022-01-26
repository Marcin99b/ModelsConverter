namespace ModelsConverter.Core.Converters
{
    public interface IConvertedProperty
    {
        string TypeName { get; }
        string PropertyName { get; }
        string Render();
    }
}
