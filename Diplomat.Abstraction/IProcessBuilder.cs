namespace Diplomat
{
    public interface IProcessBuilder
    {
        IProcessBuilder Use(Func<ProcessDelegate, ProcessDelegate> process);

        IProcessBuilder UseProcess<T, IT, OT>(Func<IT, OT> modelBuilder);

        IProcessBuilder UseProcess<T, OT>(Func<OT> modelBuilder);
        
        IProcessBuilder UseProcess<T>();

        ProcessDelegate Build();
    }
}
