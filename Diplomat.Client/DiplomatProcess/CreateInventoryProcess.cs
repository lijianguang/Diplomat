using Diplomat.Core;
using MultipleIntegration.Proxy;
using MultipleIntegration.Proxy.Model;

namespace MultipleIntegration.DiplomatProcess
{
    public class CreateInventoryProcess : Process<Inventory>
    {
        private readonly IInventoryProxy _inventoryProxy;

        public CreateInventoryProcess(IInventoryProxy inventoryProxy)
        {
            _inventoryProxy = inventoryProxy;
        }

        protected override void Execute(Inventory inventory, Action next)
        {
            _inventoryProxy.Create(inventory);
            next();
        }
    }
}
