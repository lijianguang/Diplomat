using MultipleIntegration.Proxy.Model;

namespace MultipleIntegration.Proxy
{
    public class InventoryProxy : IInventoryProxy
    {
        public Inventory Create(Inventory inventory)
        {
            Console.WriteLine($"Create inventory, VIN: {inventory.VIN}, Price: {inventory.Price}");
            return inventory;
        }

        public void Remove(long id)
        {
            Console.WriteLine($"Remove inventory, Id: {id}");
        }

        public void Update(Inventory inventory)
        {
            Console.WriteLine($"Update inventory, VIN: {inventory.VIN}, Price: {inventory.Price}");
        }
    }
}
