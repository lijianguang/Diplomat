using MultipleIntegration.Proxy.Model;
using MultipleIntegration.Proxy;
using Diplomat.Core;

namespace MultipleIntegration.DiplomatProcess
{
    public class UpdateInventoryProcess : Process<Inventory>
    {
        private readonly IInventoryProxy _inventoryProxy;

        public UpdateInventoryProcess(IInventoryProxy inventoryProxy)
        {
            _inventoryProxy = inventoryProxy;
        }

        protected override void Execute(Inventory inventory, Action next)
        {
            _inventoryProxy.Update(inventory);
            next();
        }
    }
}
