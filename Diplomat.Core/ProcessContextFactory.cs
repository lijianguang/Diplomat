namespace Diplomat.Core
{
    public class ProcessContextFactory : IProcessContextFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public ProcessContextFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public ProcessContext Create<T>(T dataSource) where T : DiplomatModel
        {
            return new ProcessContext(_serviceProvider, dataSource);
        }
    }
}
