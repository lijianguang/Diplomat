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

        protected override bool IsOpened(Market market, Source source)
        {
            return true;
        }

        protected override void Failed(ProcessContext context)
        {
            throw new NotImplementedException();
        }
        protected override void Successed(ProcessContext context)
        {
            throw new NotImplementedException();
        }
    }
}
