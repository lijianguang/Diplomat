using Microsoft.Extensions.DependencyInjection;

namespace Diplomat.Core
{
    public class ProcessFactory : IProcessFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public ProcessFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public IProcess? Create(Type processType)
        {
            return _serviceProvider.GetRequiredService(processType) as IProcess;
        }
    }
}
