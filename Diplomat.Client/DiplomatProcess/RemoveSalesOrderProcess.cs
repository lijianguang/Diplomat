using Diplomat.Core;
using MultipleIntegration.Proxy;
using MultipleIntegration.Proxy.Model;

namespace MultipleIntegration.DiplomatProcess
{
    public class RemoveSalesOrderProcess : Process<int>
    {
        private readonly ISalesOrderProxy _salesOrderProxy;

        public RemoveSalesOrderProcess(ISalesOrderProxy salesOrderProxy)
        {
            _salesOrderProxy = salesOrderProxy;
        }

        protected override void Execute(int id, Action next)
        {
            _salesOrderProxy.Remove(id);
            next();
        }
    }
}
