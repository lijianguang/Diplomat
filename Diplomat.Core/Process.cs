using Diplomat.Abstraction;

namespace Diplomat.Core
{
    public abstract class Process<T> : IProcess
    {
        protected abstract void Execute(T model);

        public void Execute(ProcessContext context, ProcessDelegate next, bool blockForException = false)
        {
            var modelBuilder = context.ResolveModelBuilder<T>(this.GetType());
            if (context.ResolveModelBuilder<T>(this.GetType()) is Func<T> func)
            {
                ProcessExecutedStatus status = ProcessExecutedStatus.Unknown;
                try
                {
                    Execute(func());
                    status = ProcessExecutedStatus.Suceeded;
                }
                catch (Exception ex)
                {
                    status = ProcessExecutedStatus.Failed;
                    if (blockForException)
                    {
                        return;
                    }
                }
                finally
                {
                    //log here whethe exception occur or not.
                    Console.WriteLine($"market: {context.Market}, source: {context.Source}, process: {this.GetType().Name}, status: {status}");
                }

                next(context);
            }
            else
            {
                throw new Exception($"Can't resolve the Func<{typeof(T).Name}> in current context");
            }
        }
    }
}
