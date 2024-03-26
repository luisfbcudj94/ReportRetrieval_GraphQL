using Blazorise.Icons.FontAwesome;
using Blazorise;
using FrontEnd_GraphQL;
using FrontEnd_GraphQL.Application.Interfaces;
using FrontEnd_GraphQL.Application.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using BlazorBootstrap;
using Blazored.Toast;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddBlazorBootstrap();
builder.Services.AddBlazorise();
builder.Services.AddBlazoredToast();

builder.Services.AddScoped<ICommissionsService, CommissionsService>();
builder.Services.AddScoped<IGraphQLClientService, GraphQLClientService>();
builder.Services.AddScoped<ICSVService, CSVService>();
builder.Services.AddScoped<ISetApisService, SetAPIsService>();
builder.Services.AddScoped<IBuildRequestService, BuildRequestService>();

//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://apigraphql20240320094558.azurewebsites.net/graphql") });

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://localhost:5222/graphql") });


await builder.Build().RunAsync();
