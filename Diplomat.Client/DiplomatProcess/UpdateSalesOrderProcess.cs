using Diplomat.Core;
using Diplomat.Client.Proxy.SalesOrder;

namespace MultipleIntegration.DiplomatProcess
{
    public class UpdateSalesOrderProcess : Process<SalesOrder>
    {
        private readonly ISalesOrderProxy _salesOrderProxy;

        public UpdateSalesOrderProcess(ISalesOrderProxy salesOrderProxy)
        {
            _salesOrderProxy = salesOrderProxy;
        }

        protected override void Execute(SalesOrder salesOrder)
        {
            _salesOrderProxy.Update(salesOrder);
        }
    }
}
