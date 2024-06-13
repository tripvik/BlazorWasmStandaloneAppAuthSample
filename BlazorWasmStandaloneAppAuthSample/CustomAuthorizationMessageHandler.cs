using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;

namespace BlazorWasmStandaloneAppAuthSample
{
    public class CustomAuthorizationMessageHandler : AuthorizationMessageHandler
    {
        public CustomAuthorizationMessageHandler(IAccessTokenProvider provider, NavigationManager navigation, IConfiguration configuration)
            : base(provider, navigation)
        {
            var url = configuration["DownstreamApi:BaseUrl"];
            var scopes = configuration.GetSection("DownstreamApi:Scopes").Get<string[]>();
            ConfigureHandler(
                authorizedUrls: [url!],
                scopes: scopes);
        }
    }
}