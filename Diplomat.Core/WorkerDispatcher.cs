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
        public void Emit<T>(T model, Market market) where T : DiplomatModel
        {
            var workerDescriptor = _workerDescriptorProvider.Get<T>(market);
            if (_serviceProvider.GetService(workerDescriptor.Type) is IWorker worker)
            {
                worker.Operate(model, market);
            }
        }
    }
}
