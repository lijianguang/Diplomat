namespace Diplomat.Core
{
    public abstract class Process<T> : IProcess
    {
        protected abstract void Execute(T model, Action next);

        public void Execute(ProcessContext context, ProcessDelegate next)
        {
            var modelBuilder = context.ResolveModelBuilder<T>(this.GetType());
            if (context.ResolveModelBuilder<T>(this.GetType()) is Func<T> func)
            {
                Execute(func(), () => next(context));
            }
            else
            {
                throw new Exception($"Can't resolve the Func<{typeof(T).Name}> in current context");
            }
        }
    }
}
