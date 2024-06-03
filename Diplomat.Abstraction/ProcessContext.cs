namespace Diplomat
{
    public class ProcessContext
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly dynamic _dataSource;
        private Dictionary<string, Delegate> modelBuilders = new Dictionary<string, Delegate>();

        public ProcessContext(IServiceProvider serviceProvider, dynamic dataSource)
        {
            _serviceProvider = serviceProvider;
            _dataSource = dataSource;
        }

        public IServiceProvider ServiceProvider { get { return _serviceProvider; } }

        public ProcessContext RegisterModelBuilder<IT, OT>(Type type, Func<IT, OT> modelBuilder)
        {
            if(type.FullName is string key)
            {
                modelBuilders[key] = () => _dataSource is IT source ? modelBuilder(source)
                        : throw new Exception($"Can't register Func<{typeof(OT).Name}> for key {key}");
                return this;
            }
            throw new Exception($"The parameter type's FullName is null.");
        }

        public Func<OT> ResolveModelBuilder<OT>(Type type)
        {
            if (type.FullName is string key)
            {
                return (Func<OT>)modelBuilders[key] ?? throw new Exception($"Can't resolve the Func<{typeof(OT).Name}> for key {key}");
            }
            throw new Exception($"The parameter type's FullName is null.");
        }
    }
}
