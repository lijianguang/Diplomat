namespace Diplomat.Core
{
    public abstract class Worker<MT> : IWorker where MT : DiplomatModel
    {
        protected Market _market;
        protected Source _source;
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
                if (Attribute.GetCustomAttribute(model.GetType(), typeof(ModelMappingAttribute)) is ModelMappingAttribute modelMapping)
                {
                    _source = modelMapping.Source;
                }
                else
                {
                    throw new Exception($"Can't identity source for worker: {this.GetType().Name}");
                }
                if(IsOpened(_market, _source))
                {
                    Operate(mt);
                }
            }
            else
            {
                throw new ArgumentNullException($"The parameter model can't be converted to {typeof(MT).Name}.");
            }
        }

        private bool IsOpened(Market market, Source source)
        {
            //to do

            return true;
        }
    }
}
