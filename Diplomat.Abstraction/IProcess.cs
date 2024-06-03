namespace Diplomat
{
    public interface IProcess
    {
        void Execute(ProcessContext context, ProcessDelegate next);
    }
}
