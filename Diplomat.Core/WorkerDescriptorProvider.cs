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
                            return attributes != null && attributes.Any() ? attributes.Select(a => (a.Source, a.Market)).ToList()
                                : new List<(Source, Market)>();
                        });
                    }
                }
                return _workerDescriptors;
            }
        }

        private IReadOnlyList<WorkerDescriptor> PickupDescriptors<T>(Func<TypeInfo, IEnumerable<(Source, Market)>> getSourceAndMarkets)
        {
            var descriptors = new List<WorkerDescriptor>();

            var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            var typesFromAssembly = assemblies.Where(x => x.DefinedTypes.Any(t => t.GetInterfaces().Any(i => i == typeof(T)))).SelectMany(x => x.DefinedTypes.Where(t => t.IsClass && t.GetInterfaces().Any(c => c == typeof(T))), (a, t) => t).ToList();
            foreach (var t in typesFromAssembly)
            {
                var sourceAndMarkets = getSourceAndMarkets(t);
                foreach (var sourceAndMarket in sourceAndMarkets)
                {
                    if (sourceAndMarket.Item1 != Source.Unknown && sourceAndMarket.Item2 != Market.Unknown)
                    {
                        descriptors.Add(new WorkerDescriptor()
                        {
                            Source = sourceAndMarket.Item1,
                            Market = sourceAndMarket.Item2,
                            Type = t,
                        });
                    }
                }
            }
            return descriptors;
        }

        public WorkerDescriptor Get(Source source, Market market)
        {
            return WorkerDescriptors.FirstOrDefault(h => h.Source == source && h.Market == market)
                ?? throw new NotImplementedException($"Can't find the WorkerDescriptor for source '{source}', market '{market}'");
        }
    }
}
