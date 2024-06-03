namespace Diplomat
{
    public interface IWorkerDescriptorProvider
    {
        WorkerDescriptor Get(Source source, Market market);
    }
}
