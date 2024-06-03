using MultipleIntegration.Proxy.Model;
using MultipleIntegration.Proxy;
using Diplomat.Core;

namespace MultipleIntegration.DiplomatProcess
{
    public class UpdateSalesOrderProcess : Process<SalesOrder>
    {
        private readonly ISalesOrderProxy _salesOrderProxy;

        public UpdateSalesOrderProcess(ISalesOrderProxy salesOrderProxy)
        {
            _salesOrderProxy = salesOrderProxy;
        }

        protected override void Execute(SalesOrder salesOrder, Action next)
        {
            _salesOrderProxy.Update(salesOrder);
            next();
        }
    }
}
