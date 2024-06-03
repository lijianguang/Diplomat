using System.Reflection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.DependencyInjection;

namespace Diplomat.Core
{
    public static class DiplomatServiceCollectionExtensions
    {
        public static void AddDiplomatServices(this IServiceCollection services)
        {
            services.AddTransient<IProcessContextFactory, ProcessContextFactory>();
            services.AddTransient<IProcessBuilder, ProcessBuilder>();
            services.AddTransient<IProcessFactory, ProcessFactory>();
            services.AddAllProcesses();

            services.AddTransient<IMessageConverter, MessageConverter>();
            services.AddTransient<IHandler, Handler>();

            services.AddSingleton<IModelDescriptorProvider, ModelDescriptorProvider>();

            services.AddAllWorkshops();
            services.AddSingleton<IWorkshopFactory, WorkshopFactory>();

            services.AddSingleton<IWorkerDescriptorProvider, WorkerDescriptorProvider>();
            services.AddTransient<IWorkerDispatcher, WorkerDispatcher>();
            services.AddAllWorkers();
        }

        public static void AddAllProcesses(this IServiceCollection services, ServiceLifetime lifetime = ServiceLifetime.Transient)
        {
            services.AddAllImplementedClasses(typeof(IProcess), (t) => new ServiceDescriptor(t, t, lifetime));
        }

        public static void AddAllWorkshops(this IServiceCollection services, ServiceLifetime lifetime = ServiceLifetime.Transient)
        {
            services.AddAllImplementedClasses(typeof(IWorkshop), (t) => t.BaseType is Type bt ? new ServiceDescriptor(bt, t, lifetime) : null);
        }

        public static void AddAllWorkers(this IServiceCollection services, ServiceLifetime lifetime = ServiceLifetime.Transient)
        {
            services.AddAllImplementedClasses(typeof(IWorker), (t) => new ServiceDescriptor(t, t, lifetime));
        }

        public static void AddAllImplementedClasses(this IServiceCollection services, Type type, Func<TypeInfo, ServiceDescriptor?> generateServiceDescriptor, bool ignoreDuplicateItem = true)
        {
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            var typesFromAssembly = assemblies.Where(x => x.DefinedTypes.Any(t => t.GetInterfaces().Any(c => c == type))).SelectMany(x => x.DefinedTypes.Where(t => !t.IsAbstract && t.IsClass && t.GetInterfaces().Any(c => c == type)), (a, t) => t).ToList();
            foreach (var t in typesFromAssembly)
            {
                if (generateServiceDescriptor(t) is ServiceDescriptor serviceDescriptor)
                {
                    if (ignoreDuplicateItem)
                    {
                        services.TryAdd(serviceDescriptor);
                    }
                    else
                    {
                        services.Add(serviceDescriptor);
                    }
                }
            }
        }
    }
}
