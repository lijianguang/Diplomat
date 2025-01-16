using Diplomat;
using Diplomat.Client.Proxy.Inventory;
using MultipleIntegration.DiplomatProcess;
using MultipleIntegration.VSS.Model;

namespace MultipleIntegration.VSS.Worker
{
    [WorkerMapping(Market.SouthAfrica)]
    public class SouthAfricaWorker : VSSWorker
    {
        public SouthAfricaWorker(IProcessBuilder processBuilder, IServiceProvider serviceProvider, IProcessContextFactory processContextFactory)
            : base(processBuilder, serviceProvider, processContextFactory)
        {
        }

        protected override void Operate(VSSModel model)
        {
            Console.WriteLine($"SouthAfricaWorker has executed; source: {Source.VSS}, market: {Market.SouthAfrica}; current market:{_market}");
            _processBuilder.UseProcess<ValidateVSSModelProcess, VSSModel, VSSModel>(m => m)
                .UseProcess<CreateInventoryProcess, VSSModel, Inventory>(m => m.ToInventory())
                .Build()
                .Invoke(_processContextFactory.Create(model, _market, _source));
        }
    }
}
