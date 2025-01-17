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
