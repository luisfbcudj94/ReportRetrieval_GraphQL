using FrontEnd_GraphQL;
using FrontEnd_GraphQL.Application.Interfaces;
using FrontEnd_GraphQL.Application.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddBlazorBootstrap();

builder.Services.AddScoped<ICommissionsService, CommissionsService>();
builder.Services.AddScoped<IGraphQLClientService, GraphQLClientService>();
builder.Services.AddScoped<ICSVService, CSVService>();

//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://apigraphql20240305094849.azurewebsites.net/graphql") });

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7012/graphql") });


await builder.Build().RunAsync();
