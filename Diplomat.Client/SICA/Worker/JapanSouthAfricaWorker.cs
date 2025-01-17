using Diplomat;
using Diplomat.Client.Proxy.Inventory;
using Diplomat.Client.Proxy.SalesOrder;
using MultipleIntegration.DiplomatProcess;
using MultipleIntegration.SICA.Model;

namespace MultipleIntegration.SICA.Worker
{
    [WorkerMapping(Market.Japan)]
    [WorkerMapping(Market.SouthAfrica)]
    public class JapanSouthAfricaWorker : SICAWorker
    {
        public JapanSouthAfricaWorker(IProcessBuilder processBuilder, IServiceProvider serviceProvider, IProcessContextFactory processContextFactory)
            : base(processBuilder, serviceProvider, processContextFactory)
        {
        }

        protected override void Operate(SICAModel model)
        {
            Console.WriteLine($"JapanSouthAfricaWorker has executed; source: {Source.SICA}, market: {Market.Japan} or {Market.SouthAfrica}; current market:{_market}");

            _processBuilder
                .UseProcess<CreateInventoryProcess, SICAModel, Inventory>(m => m.ToInventory())
                .UseProcess<CreateSalesOrderProcess, SICAModel, SalesOrder>(m => m.ToSalesOrder())
                .Build()
                .Invoke(_processContextFactory.Create(model, _market, _source));
        }
    }
}
