namespace Diplomat
{
    public interface IProcessContextFactory
    {
        ProcessContext Create<T>(T dataSource, Market market, Source source) where T : DiplomatModel;
    }
}
