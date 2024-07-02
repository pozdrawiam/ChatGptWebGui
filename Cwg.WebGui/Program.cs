using Cwg.Core.Services;
using Cwg.Infrastructure.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Cwg.WebGui;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddTransient<IChatService, ChatService>();

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

await builder.Build().RunAsync();
