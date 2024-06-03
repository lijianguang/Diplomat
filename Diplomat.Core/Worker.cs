namespace Diplomat.Core
{
    public abstract class Worker<MT> : IWorker where MT : DiplomatModel
    {
        protected Market _market;
        protected readonly IProcessBuilder _processBuilder;
        protected readonly IServiceProvider _serviceProvider;
        protected readonly IProcessContextFactory _processContextFactory;

        public Worker(IProcessBuilder processBuilder,
            IServiceProvider serviceProvider,
            IProcessContextFactory processContextFactory)
        {
            _processBuilder = processBuilder;
            _serviceProvider = serviceProvider;
            _processContextFactory = processContextFactory;
        }

        protected abstract void Operate(MT model);

        public virtual void Operate<T>(T model, Market market) where T : DiplomatModel
        {
            _market = market;

            if (model is MT mt)
            {
                Operate(mt);
            }
            else
            {
                throw new ArgumentNullException($"The parameter model can't be converted to {typeof(MT).Name}.");
            }
        }
    }
}
