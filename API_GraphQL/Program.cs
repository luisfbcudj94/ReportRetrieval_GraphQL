using API_GraphQL.Application.Interfaces;
using API_GraphQL.Application.Services;
using API_GraphQL.GraphQL;
using HotChocolate.AspNetCore;
using HotChocolate.AspNetCore.Playground;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<ICommissionsGenerator, CommissionsGenerator>();
builder.Services.AddSingleton<ICommisionsService, CommisionsService>();

builder.Services.AddGraphQLServer()
    .AddQueryType<Query>()
    .AddType<CommissionType>()
    ;


builder.Services.AddCors(options =>
{
    options.AddPolicy("MyCors", builder =>
    {
        builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});


var app = builder.Build();

app.UseRouting();

app.UseCors("MyCors");

app.MapGraphQL();

app.Run();
