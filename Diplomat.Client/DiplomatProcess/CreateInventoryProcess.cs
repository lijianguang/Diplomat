using Diplomat.Client.Proxy.Inventory;
using Diplomat.Core;

namespace MultipleIntegration.DiplomatProcess
{
    public class CreateInventoryProcess : Process<Inventory>
    {
        private readonly IInventoryProxy _inventoryProxy;

        public CreateInventoryProcess(IInventoryProxy inventoryProxy)
        {
            _inventoryProxy = inventoryProxy;
        }

        protected override void Execute(Inventory inventory)
        {
            _inventoryProxy.Create(inventory);
        }
    }
}
