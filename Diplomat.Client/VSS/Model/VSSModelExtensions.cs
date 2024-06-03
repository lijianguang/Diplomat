using MultipleIntegration.Proxy.Model;

namespace MultipleIntegration.VSS.Model
{
    public static class VSSModelExtensions
    {
        public static SalesOrder ToSalesOrder(this VSSModel vssModel)
        {
            return new SalesOrder
            {
                Price = vssModel.Price,
                Number = $"NO-{vssModel.Name}",
            };
        }
        public static Inventory ToInventory(this VSSModel vssModel)
        {
            return new Inventory
            {
                VIN = $"VIN-{vssModel.Name}",
                Price = vssModel.Price,
            };
        }
    }
}
