namespace Diplomat.Core
{
    public abstract class Workshop<T> : IWorkshop where T : DiplomatModel
    {
        protected readonly IWorkerDispatcher _workerDispatcher;
        protected readonly IMessageConverter _messageConverter;
        protected Workshop(IWorkerDispatcher workerDispatcher, IMessageConverter messageConverter)
        {
            _workerDispatcher = workerDispatcher;
            _messageConverter = messageConverter;
        }
        public virtual void Dispatch(T model, Market[] markets)
        {
            foreach (Market market in markets)
            {
                _workerDispatcher.Emit(model, market);
            }
        }
        public abstract Market[] IdentityMarket(T model);

        public void Process(string message)
        {
            T model = _messageConverter.Convert<T>(message);
            Dispatch(model, IdentityMarket(model));
        }
    }
}
