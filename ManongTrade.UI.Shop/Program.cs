using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using ManongTrade.UI.Shop.Services;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;

namespace ManongTrade.UI.Shop
{
    public static class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);

            builder.RootComponents.Add<App>("app");
            builder.Services.AddScoped(_ => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            //Manong customs
            builder.Services.AddBlazoredLocalStorage();
            builder.Services.AddOptions();
            builder.Services.AddAuthorizationCore();
            builder.Services.AddScoped<AuthenticationStateProvider, LocalAuthenticationStateProvider>();
            builder.Services.AddScoped<AuthenticationService>(_ => new AuthenticationService(builder.Configuration["WebApiUrl"]));

            await builder.Build().RunAsync().ConfigureAwait(false);
        }
    }
}
