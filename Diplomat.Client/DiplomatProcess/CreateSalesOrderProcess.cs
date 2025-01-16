using Diplomat.Client.Proxy.SalesOrder;
using Diplomat.Core;

namespace MultipleIntegration.DiplomatProcess
{
    public class CreateSalesOrderProcess : Process<SalesOrder>
    {
        private readonly ISalesOrderProxy _salesOrderProxy;

        public CreateSalesOrderProcess(ISalesOrderProxy salesOrderProxy)
        {
            _salesOrderProxy = salesOrderProxy;
        }

        protected override void Execute(SalesOrder salesOrder)
        {
            _salesOrderProxy.Create(salesOrder);
        }
    }
}
