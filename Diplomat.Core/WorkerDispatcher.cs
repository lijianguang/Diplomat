namespace Diplomat.Core
{
    public class WorkerDispatcher : IWorkerDispatcher
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IWorkerDescriptorProvider _workerDescriptorProvider;

        public WorkerDispatcher(IServiceProvider serviceProvider,
            IWorkerDescriptorProvider workerDescriptorProvider)
        {
            _serviceProvider = serviceProvider;
            _workerDescriptorProvider = workerDescriptorProvider;
        }
        public void Emit<T>(T model, Source source, Market market) where T : DiplomatModel
        {
            var workerDescriptor = _workerDescriptorProvider.Get(source, market);
            if (_serviceProvider.GetService(workerDescriptor.Type) is IWorker worker)
            {
                worker.Operate(model, market);
            }
        }
    }
}
