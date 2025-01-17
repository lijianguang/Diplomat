using Diplomat.Abstraction;

namespace Diplomat.Core
{
    public abstract class Process<T> : IProcess
    {
        protected abstract void Execute(T model);

        public void Execute(ProcessContext context, ProcessDelegate next, Action<ProcessContext> onSuccessed, Action<ProcessContext> onFailed, bool blockForException = false)
        {
            if (context.ResolveModelBuilder<T>(this.GetType()) is Func<T> func)
            {
                T model = func();
                try
                {
                    context.TakeSnapshot(this,model);
                    Execute(model);
                    onSuccessed(context);
                }
                catch (Exception ex)
                {
                    context.TakeSnapshot(this, model, ex);
                    onFailed(context);
                    if (blockForException)
                    {
                        return;
                    }
                }
                finally
                {
                    //whether exception occur or not.
                    context.ClearSnapshot();
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
