using BlazorWasmStandaloneAppAuthSample;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddTransient<CustomAuthorizationMessageHandler>();

builder.Services.AddHttpClient("WeatherForecastApi",
        client => client.BaseAddress = new Uri(builder.Configuration["DownstreamApi:BaseUrl"] ?? throw new Exception("BaseUrl is not defiend in appsettings")))
    .AddHttpMessageHandler<CustomAuthorizationMessageHandler>();

var scopes = builder.Configuration.GetSection("DownstreamApi:Scopes").Get<string[]>() ?? throw new Exception("Scope is not defiend in appsettings");

builder.Services.AddMsalAuthentication(options =>
{
    builder.Configuration.Bind("AzureAd", options.ProviderOptions.Authentication);
    options.ProviderOptions.DefaultAccessTokenScopes = scopes;
    options.ProviderOptions.LoginMode = "Redirect";
    options.ProviderOptions.Cache.CacheLocation = "localStorage";
});

await builder.Build().RunAsync();
