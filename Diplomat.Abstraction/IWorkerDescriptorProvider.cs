namespace Diplomat
{
    public interface IWorkerDescriptorProvider
    {
        WorkerDescriptor Get<T>(Market market);
    }
}
