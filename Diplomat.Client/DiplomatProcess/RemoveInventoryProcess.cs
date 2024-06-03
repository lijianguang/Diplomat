using MultipleIntegration.Proxy.Model;
using MultipleIntegration.Proxy;
using Diplomat.Core;

namespace MultipleIntegration.DiplomatProcess
{
    public class RemoveInventoryProcess : Process<Inventory>
    {
        private readonly IInventoryProxy _inventoryProxy;

        public RemoveInventoryProcess(IInventoryProxy inventoryProxy)
        {
            _inventoryProxy = inventoryProxy;
        }

        protected override void Execute(Inventory inventory, Action next)
        {
            _inventoryProxy.Remove(inventory.Id);
            next();
        }
    }
}
