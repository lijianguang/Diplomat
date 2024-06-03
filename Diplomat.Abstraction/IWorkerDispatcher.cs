namespace Diplomat
{
    public interface IWorkerDispatcher
    {
        void Emit<T>(T model, Source source, Market market) where T : DiplomatModel;
    }
}
