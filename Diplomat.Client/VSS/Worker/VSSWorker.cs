using Diplomat;
using Diplomat.Core;
using MultipleIntegration.VSS.Model;

namespace MultipleIntegration.VSS.Worker
{
    public abstract class VSSWorker : Worker<VSSModel>
    {
        protected VSSWorker(IProcessBuilder processBuilder, IServiceProvider serviceProvider, IProcessContextFactory processContextFactory)
            : base(processBuilder, serviceProvider, processContextFactory)
        {
        }
    }
}
