namespace Diplomat
{
    public interface IModelDescriptorProvider
    {
        ModelDescriptor Get(Source source);
        ModelDescriptor Get(Type type);
    }
}
