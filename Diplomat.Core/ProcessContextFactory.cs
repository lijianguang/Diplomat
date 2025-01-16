namespace Diplomat.Core
{
    public class ProcessContextFactory : IProcessContextFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public ProcessContextFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public ProcessContext Create<T>(T dataSource, Market market, Source source) where T : DiplomatModel
        {
            return new ProcessContext(_serviceProvider, dataSource, market, source);
        }
    }
}
