using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MiFrontendBlazor;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// Configurar el HttpClient para la API
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://localhost:5155") });

await builder.Build().RunAsync();
