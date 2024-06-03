using MultipleIntegration.Proxy.Model;

namespace MultipleIntegration.Proxy
{
    public interface IInventoryProxy
    {
        public Inventory Create(Inventory inventory);
        public void Update(Inventory inventory);
        public void Remove(long id);
    }
}
