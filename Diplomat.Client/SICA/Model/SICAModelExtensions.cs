using MultipleIntegration.Proxy.Model;

namespace MultipleIntegration.SICA.Model
{
    public static class SICAModelExtensions
    {
        public static SalesOrder ToSalesOrder(this SICAModel sicaModel)
        {
            return new SalesOrder
            {
                Price = sicaModel.Price,
                Number = $"NO-{sicaModel.Number}",
            };
        }
        public static Inventory ToInventory(this SICAModel sicaModel)
        {
            return new Inventory
            {
                VIN = $"VIN-{sicaModel.Number}",
                Price = sicaModel.Price,
            };
        }
    }
}
