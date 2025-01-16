using Diplomat.Core;
using Diplomat.Client.Proxy.Inventory;

namespace MultipleIntegration.DiplomatProcess
{
    public class UpdateInventoryProcess : Process<Inventory>
    {
        private readonly IInventoryProxy _inventoryProxy;

        public UpdateInventoryProcess(IInventoryProxy inventoryProxy)
        {
            _inventoryProxy = inventoryProxy;
        }

        protected override void Execute(Inventory inventory)
        {
            _inventoryProxy.Update(inventory);
        }
    }
}
