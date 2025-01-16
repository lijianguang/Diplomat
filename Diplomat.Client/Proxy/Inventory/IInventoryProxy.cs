namespace Diplomat.Client.Proxy.Inventory
{
    public interface IInventoryProxy
    {
        public Inventory Create(Inventory inventory);
        public void Update(Inventory inventory);
        public void Remove(long id);
    }
}
