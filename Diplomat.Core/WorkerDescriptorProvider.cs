using System.Reflection;

namespace Diplomat.Core
{
    public class WorkerDescriptorProvider : IWorkerDescriptorProvider
    {
        private static object _lock = new object();
        private IReadOnlyList<WorkerDescriptor>? _workerDescriptors;

        protected IReadOnlyList<WorkerDescriptor> WorkerDescriptors
        {
            get
            {
                if (_workerDescriptors == null)
                {
                    lock (_lock)
                    {
                        _workerDescriptors = _workerDescriptors ?? PickupDescriptors<IWorker>((t) =>
                        {
                            var attributes = t.GetCustomAttributes<WorkerMappingAttribute>();
                            return attributes != null && attributes.Any() ? attributes.Select(a => a.Market).ToList()
                                : new List<Market>();
                        });
                    }
                }
                return _workerDescriptors;
            }
        }

        private Type? DetectGenericTypeForWorker(Type type)
        {
            if(type.IsAbstract && type.IsGenericType && type.GenericTypeArguments.Length == 1)
            {
                return type.GetGenericArguments()[0];
            }
            return type.BaseType != null ? DetectGenericTypeForWorker(type.BaseType) : default;
        }

        private IReadOnlyList<WorkerDescriptor> PickupDescriptors<T>(Func<TypeInfo, IEnumerable<Market>> getMarkets)
        {
            var descriptors = new List<WorkerDescriptor>();

            var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            var typesFromAssembly = assemblies.Where(x => x.DefinedTypes.Any(t => t.GetInterfaces().Any(i => i == typeof(T)))).SelectMany(x => x.DefinedTypes.Where(t => t.IsClass && t.GetInterfaces().Any(c => c == typeof(T))), (a, t) => t).ToList();
            
            foreach (var t in typesFromAssembly)
            {
                var operateModelType = DetectGenericTypeForWorker(t);
                if(operateModelType == null)
                {
                    continue;
                }
                
                var markets = getMarkets(t);
                foreach (var market in markets)
                {
                    if (market != Market.Unknown)
                    {
                        descriptors.Add(new WorkerDescriptor()
                        {
                            OperateModelType = operateModelType,
                            Market = market,
                            Type = t,
                        });
                    }
                }
            }
            return descriptors;
        }

        public WorkerDescriptor Get<T>(Market market)
        {
            return WorkerDescriptors.FirstOrDefault(h => h.OperateModelType == typeof(T) && h.Market == market)
                ?? throw new NotImplementedException($"Can't find the WorkerDescriptor for type '{typeof(T).Name}', market '{market}'");
        }
    }
}
