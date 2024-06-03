using Diplomat;
using Diplomat.Core;
using MultipleIntegration.SICA.Model;

namespace MultipleIntegration.SICA.Worker
{
    public abstract class SICAWorker : Worker<SICAModel>
    {
        protected SICAWorker(IProcessBuilder processBuilder, IServiceProvider serviceProvider, IProcessContextFactory processContextFactory)
            : base(processBuilder, serviceProvider, processContextFactory)
        {
        }
    }
}
