namespace Diplomat
{
    public interface IWorkerDispatcher
    {
        void Emit<T>(T model, Market market) where T : DiplomatModel;
    }
}
