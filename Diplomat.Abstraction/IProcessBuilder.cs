﻿namespace Diplomat
{
    public interface IProcessBuilder
    {
        IProcessBuilder Use(Func<ProcessDelegate, ProcessDelegate> process);

        IProcessBuilder UseProcess<T, IT, OT>(Func<IT, OT> modelBuilder, bool blockForException = false);

        IProcessBuilder UseProcess<T, OT>(Func<OT> modelBuilder, bool blockForException = false);
        
        IProcessBuilder UseProcess<T>(bool blockForException = false);

        IProcessBuilder OnProcessSuccessed(Action<ProcessContext> onSuccessed);

        IProcessBuilder OnProcessFailed(Action<ProcessContext> onFailed);

        ProcessDelegate Build();
    }
}
