using System.Reflection.Emit;

namespace Diplomat.Core
{
    public class ProcessBuilder : IProcessBuilder
    {
        private readonly List<Func<ProcessDelegate, ProcessDelegate>> _components = new();

        public IProcessBuilder Use(Func<ProcessDelegate, ProcessDelegate> process)
        {
            _components.Add(process);
            return this;
        }
        public IProcessBuilder UseProcess<T, IT, OT>(Func<IT, OT> modelBuilder)
        {
            return UseProcess(typeof(T), modelBuilder);
        }
        public IProcessBuilder UseProcess<T, OT>(Func<OT> modelBuilder)
        {
            return UseProcess<object, OT>(typeof(T), (_) => modelBuilder());
        }

        public IProcessBuilder UseProcess<T>()
        {
            return UseProcess<object, object>(typeof(T));
        }

        private IProcessBuilder UseProcess<IT, OT>(Type processType, Func<IT, OT>? modelBuilder = null)
        {
            if (typeof(IProcess).IsAssignableFrom(processType))
            {
                return Use(next =>
                {
                    return (context) =>
                    {
                        var processFactory = (IProcessFactory?)context.ServiceProvider.GetService(typeof(IProcessFactory));
                        if (processFactory == null)
                        {
                            // No process factory
                            throw new InvalidOperationException("Can't find the implement of IProcessFactory");
                        }

                        var process = processFactory.Create(processType);
                        if (process == null)
                        {
                            // The factory returned null, it's a broken implementation
                            throw new InvalidOperationException($"Can't find the instance of {processType.FullName}");
                        }

                        if(modelBuilder!= null)
                        {
                            context.RegisterModelBuilder(processType, modelBuilder);
                        }

                        process.Execute(context, next);
                    };
                });
            }
            throw new NotImplementedException($"Type {processType.FullName} does not implement interface IProcess");
        }

        public ProcessDelegate Build()
        {
            ProcessDelegate app = (model) =>
            {
                //ending
            };
            for (var c = _components.Count - 1; c >= 0; c--)
            {
                app = _components[c](app);
            }

            return app;
        }

    }
}
