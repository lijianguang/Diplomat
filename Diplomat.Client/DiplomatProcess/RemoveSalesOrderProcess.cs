using Diplomat.Client.Proxy.SalesOrder;
using Diplomat.Core;

namespace MultipleIntegration.DiplomatProcess
{
    public class RemoveSalesOrderProcess : Process<int>
    {
        private readonly ISalesOrderProxy _salesOrderProxy;

        public RemoveSalesOrderProcess(ISalesOrderProxy salesOrderProxy)
        {
            _salesOrderProxy = salesOrderProxy;
        }

        protected override void Execute(int id)
        {
            _salesOrderProxy.Remove(id);
        }
    }
}
