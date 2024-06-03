using Diplomat.Core;
using MultipleIntegration.Proxy;
using MultipleIntegration.Proxy.Model;

namespace MultipleIntegration.DiplomatProcess
{
    public class RemoveSalesOrderProcess : Process<SalesOrder>
    {
        private readonly ISalesOrderProxy _salesOrderProxy;

        public RemoveSalesOrderProcess(ISalesOrderProxy salesOrderProxy)
        {
            _salesOrderProxy = salesOrderProxy;
        }

        protected override void Execute(SalesOrder salesOrder, Action next)
        {
            _salesOrderProxy.Remove(salesOrder.Id);
            next();
        }
    }
}
