using MultipleIntegration.Proxy.Model;

namespace MultipleIntegration.Proxy
{
    public interface ISalesOrderProxy
    {
        public SalesOrder Create(SalesOrder salesOrder);
        public void Update(SalesOrder salesOrder);
        public void Remove(long id);
    }
}
