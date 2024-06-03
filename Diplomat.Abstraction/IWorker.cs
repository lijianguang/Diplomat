namespace Diplomat
{
    public interface IWorker
    {
        void Operate<T>(T model, Market market) where T : DiplomatModel;
    }
}
