using Blazored.LocalStorage;
using Cwg.Core.Services;
using Cwg.Infrastructure.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Cwg.WebGui;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddTransient<IChatService, ChatService>();
builder.Services.AddTransient<ISettingsService, SettingsService>();
builder.Services.AddTransient<IChatDbService, ChatDbService>();

builder.Services.AddBlazoredLocalStorage();

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(_ => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

await builder.Build().RunAsync();
