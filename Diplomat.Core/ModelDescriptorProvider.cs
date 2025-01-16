using System.Reflection;

namespace Diplomat.Core
{
    public class ModelDescriptorProvider : IModelDescriptorProvider
    {
        private static object _lock = new object();
        private IReadOnlyList<ModelDescriptor>? _messageModelDescriptors;

        private IReadOnlyList<ModelDescriptor> MessageModelDescriptors
        {
            get
            {
                if (_messageModelDescriptors == null)
                {
                    lock (_lock)
                    {
                        _messageModelDescriptors = _messageModelDescriptors ?? PickupDescriptors<DiplomatModel>((t) => t.GetCustomAttribute<ModelMappingAttribute>() is ModelMappingAttribute attribute ? attribute.Source : Source.Unknown);
                    }
                }
                return _messageModelDescriptors;
            }
        }

        private IReadOnlyList<ModelDescriptor> PickupDescriptors<T>(Func<TypeInfo, Source> getSource)
        {
            var descriptors = new List<ModelDescriptor>();

            var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            var typesFromAssembly = assemblies.Where(x => x.DefinedTypes.Any(t => t.IsSubclassOf(typeof(T)))).SelectMany(x => x.DefinedTypes.Where(t => t.IsClass && t.IsSubclassOf(typeof(T))), (a, t) => t).ToList();
            foreach (var t in typesFromAssembly)
            {
                var source = getSource(t);
                if (source != Source.Unknown)
                {
                    descriptors.Add(new ModelDescriptor()
                    {
                        Source = source,
                        Type = t,
                    });
                }
            }
            return descriptors;
        }

        public ModelDescriptor Get(Source source)
        {
            return MessageModelDescriptors.FirstOrDefault(h => h.Source == source)
                ?? throw new NotImplementedException($"Can't find the ModelDescriptor for source: '{source}'");
        }

        public ModelDescriptor Get(Type type)
        {
            return MessageModelDescriptors.FirstOrDefault(h => h.Type.Equals(type))
                ?? throw new NotImplementedException($"Can't find the ModelDescriptor for type: '{type}'");
        }
    }
}
