using MultipleIntegration.Proxy.Model;
using MultipleIntegration.Proxy;
using Diplomat.Core;

namespace MultipleIntegration.DiplomatProcess
{
    public class RemoveInventoryProcess : Process<int>
    {
        private readonly IInventoryProxy _inventoryProxy;

        public RemoveInventoryProcess(IInventoryProxy inventoryProxy)
        {
            _inventoryProxy = inventoryProxy;
        }

        protected override void Execute(int id, Action next)
        {
            _inventoryProxy.Remove(id);
            next();
        }
    }
}
