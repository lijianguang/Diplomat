using Diplomat;
using Diplomat.Client.Proxy.Inventory;
using MultipleIntegration.DiplomatProcess;
using MultipleIntegration.VSS.Model;

namespace MultipleIntegration.VSS.Worker
{
    [WorkerMapping(Market.Japan)]
    public class JapanWorker : VSSWorker
    {
        public JapanWorker(IProcessBuilder processBuilder, IServiceProvider serviceProvider, IProcessContextFactory processContextFactory)
            : base(processBuilder, serviceProvider, processContextFactory)
        {
        }

        protected override void Operate(VSSModel model)
        {
            Console.WriteLine($"JapanWorker has executed; source: {Source.VSS}, market: {Market.Japan}; current market:{_market}");
            _processBuilder
                .UseProcess<ValidateVSSModelProcess, VSSModel, VSSModel>(m => m)
                .UseProcess<RemoveInventoryProcess, int>(() => 5)
                .UseProcess<CreateInventoryProcess, VSSModel, Inventory>(m => m.ToInventory())
                .Build()
                .Invoke(_processContextFactory.Create(model, _market, _source));
        }
    }
}
