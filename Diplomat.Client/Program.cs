using Diplomat.Client.Proxy.Inventory;
using Diplomat.Client.Proxy.SalesOrder;
using Diplomat.Core;
using MultipleIntegration;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddHostedService<Worker>();

builder.Services.AddDiplomatServices();

builder.Services.AddTransient<ISalesOrderProxy, SalesOrderProxy>();
builder.Services.AddTransient<IInventoryProxy, InventoryProxy>();

var host = builder.Build();
host.Run();
