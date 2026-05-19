using Leads.Application;
using Leads.Infra;
using Leads.WebAPI;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddWebApi();
builder.Services.AddApplication();
builder.Services.AddInfrastructure();

var app = builder.Build();

app.ConfigurePipeline();

app.Run();