namespace Diplomat
{
    public interface IProcessFactory
    {
        IProcess? Create(Type processType);
    }
}
