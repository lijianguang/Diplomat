using Microsoft.Extensions.DependencyInjection;

namespace Diplomat.Core
{
    public sealed class WorkshopFactory : IWorkshopFactory
    {
        private static object _lock = new object();
        private Dictionary<Type, Func<IWorkshop>> _workshopDelegates;
        private readonly IServiceProvider _serviceProvider;
        private readonly IModelDescriptorProvider _modelDescriptorProvider;

        public WorkshopFactory(IServiceProvider serviceProvider, IModelDescriptorProvider modelDescriptorProvider)
        {
            _serviceProvider = serviceProvider ?? throw new ArgumentNullException("parameter 'serviceProvider' is null.");
            _workshopDelegates = new Dictionary<Type, Func<IWorkshop>>();
            _modelDescriptorProvider = modelDescriptorProvider;
        }

        public IWorkshop Create(Source source)
        {
            return GetOrCreateIWorkshopFunc(_modelDescriptorProvider.Get(source).Type)();
        }

        private Workshop<T> CreateWithSpecificGeneric<T>() where T : DiplomatModel
        {
            return _serviceProvider.GetRequiredService<Workshop<T>>();
        }

        private Func<IWorkshop> CreateIWorkshopFunc(Type workshopGenericType)
        {
            var method = GetType().GetMethod(nameof(this.CreateWithSpecificGeneric), System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
                                ?? throw new NotImplementedException("Can't find the method 'CreateWithSpecificGeneric<>'");
            var generic = method.MakeGenericMethod(workshopGenericType);
            return (Func<IWorkshop>)generic.CreateDelegate(typeof(Func<IWorkshop>), this);
        }

        private Func<IWorkshop> GetOrCreateIWorkshopFunc(Type workshopGenericType)
        {
            if (!_workshopDelegates.TryGetValue(workshopGenericType, out var func))
            {
                lock (_lock)
                {
                    _workshopDelegates[workshopGenericType] = func ?? CreateIWorkshopFunc(workshopGenericType);

                }
            }
            return _workshopDelegates[workshopGenericType];
        }
    }
}
