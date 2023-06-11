using BlazorWasmHostedMudBlazorGraphqlTemplate.Client;
using BlazorWasmHostedMudBlazorGraphqlTemplate.Client.GraphQL;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddMudServices();
builder.Services
    .AddHttpClient(
        SampleClient.ClientName,
        client =>
        {
            client.BaseAddress = new Uri($"{builder.HostEnvironment.BaseAddress}graphql");
        })
    .AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();
builder.Services.AddSampleClient();

builder.Services.AddOidcAuthentication(options =>
{
    builder.Configuration.Bind("Auth0", options.ProviderOptions);
    options.ProviderOptions.ResponseType = "code";
    options.ProviderOptions.AdditionalProviderParameters.Add("audience", builder.Configuration["Auth0:Audience"]);
});

await builder.Build().RunAsync();
