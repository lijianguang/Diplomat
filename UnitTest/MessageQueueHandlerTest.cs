using Diplomat;
using Diplomat.Client.Proxy.Inventory;
using Diplomat.Client.Proxy.SalesOrder;
using Diplomat.Core;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace UnitTest.Diplomat
{
    public class MessageQueueHandlerTest
    {
        private IServiceProvider _serviceProvider;
        private string[] _vssMessages = {
            //target market is Japan
            "<?xml version=\"1.0\" encoding=\"utf-16\"?><VSSModel><Market>Japan</Market><Name>Japan</Name><Price>100</Price></VSSModel>",
            ////target market is SouthAfrica
            //"<?xml version =\"1.0\" encoding=\"utf-16\"?><VSSModel><Market>SouthAfrica</Market><Name>SouthAfrica</Name><Price>200</Price></VSSModel>",
            ////target market is Japan and SouthAfrica
            //"<?xml version=\"1.0\" encoding=\"utf-16\"?><VSSModel><Market>ALL</Market><Name>Hello world</Name><Price>300</Price></VSSModel>",
            ////target market is Japan and SouthAfrica
            //"<?xml version=\"1.0\" encoding=\"utf-16\"?><VSSModel><Market>ALL</Market><Name>Hello world</Name><Price>0</Price></VSSModel>",
        };
        private string[] _sicaMessages =
        {
            //target market is Japan and SouthAfrica
            "<?xml version=\"1.0\" encoding=\"utf-16\"?><SICAModel><Market>ALL</Market><Number>123</Number><Price>140</Price></SICAModel>",
            //target market is Japan
            "<?xml version=\"1.0\" encoding=\"utf-16\"?><SICAModel><Market>JP</Market><Number>1</Number><Price>170</Price></SICAModel>",
            //target market is SouthAfrica
            "<?xml version=\"1.0\" encoding=\"utf-16\"?><SICAModel><Market>ZA</Market><Number>1</Number><Price>170</Price></SICAModel>",
        };

        [SetUp]
        public void Setup()
        {
            var builder = Host.CreateDefaultBuilder([])
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddOptions<HostOptions>().Configure(
                           opts => opts.ShutdownTimeout = TimeSpan.FromSeconds(60));

                    services.AddDiplomatServices();

                    services.AddTransient<ISalesOrderProxy, SalesOrderProxy>();
                    services.AddTransient<IInventoryProxy, InventoryProxy>();

                });
            var host = builder.Build();
            _serviceProvider = host.Services;
        }

        [Test]
        public void TestMessageQueueHandlerForVSS()
        {
            var handler = _serviceProvider.GetRequiredService<IHandler>();

            Console.WriteLine("------------------------------- VSS -------------------------------");
            foreach (var message in _vssMessages)
            {
                Console.WriteLine(message);
                handler.Handle(Source.VSS, message);
                Console.WriteLine();
            }
        }

        [Test]
        public void TestMessageQueueHandlerForSICA()
        {
            var handler = _serviceProvider.GetRequiredService<IHandler>();

            Console.WriteLine("------------------------------- SICA -------------------------------");
            foreach (var message in _sicaMessages)
            {
                Console.WriteLine(message);
                handler.Handle(Source.SICA, message);
                Console.WriteLine();
            }
        }
    }
}