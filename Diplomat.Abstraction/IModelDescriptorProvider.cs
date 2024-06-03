namespace Diplomat
{
    public interface IModelDescriptorProvider
    {
        ModelDescriptor Get(Source source);
    }
}
