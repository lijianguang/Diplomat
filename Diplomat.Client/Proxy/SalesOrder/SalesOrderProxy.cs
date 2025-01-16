namespace Diplomat.Client.Proxy.SalesOrder
{
    public class SalesOrderProxy : ISalesOrderProxy
    {
        public SalesOrder Create(SalesOrder salesOrder)
        {
            Console.WriteLine($"Create sales order, Number: {salesOrder.Number}, Price: {salesOrder.Price}");
            return salesOrder;
        }

        public void Remove(long id)
        {
            Console.WriteLine($"Remove sales order, Id: {id}");
        }

        public void Update(SalesOrder salesOrder)
        {
            Console.WriteLine($"Update sales order, Number: {salesOrder.Number}, Price: {salesOrder.Price}");
        }
    }
}
