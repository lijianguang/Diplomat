namespace Diplomat
{
    public interface IProcess
    {
        void Execute(ProcessContext context, ProcessDelegate next, Action<ProcessContext> onSuccessed, Action<ProcessContext> onFailed, bool blockForException = false);
    }
}
