namespace Diplomat
{
    public interface IProcessContextFactory
    {
        ProcessContext Create<T>(T dataSource) where T : DiplomatModel;
    }
}
