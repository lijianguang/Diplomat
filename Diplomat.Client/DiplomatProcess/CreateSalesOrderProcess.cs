using Diplomat.Core;
using MultipleIntegration.Proxy;
using MultipleIntegration.Proxy.Model;

namespace MultipleIntegration.DiplomatProcess
{
    public class CreateSalesOrderProcess : Process<SalesOrder>
    {
        private readonly ISalesOrderProxy _salesOrderProxy;

        public CreateSalesOrderProcess(ISalesOrderProxy salesOrderProxy)
        {
            _salesOrderProxy = salesOrderProxy;
        }

        protected override void Execute(SalesOrder salesOrder, Action next)
        {
            _salesOrderProxy.Create(salesOrder);
            next();
        }
    }
}
