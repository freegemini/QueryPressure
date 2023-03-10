using Autofac;
using Autofac.Extensions.DependencyInjection;
using QueryPressure.App.Arguments;
using QueryPressure.App.Interfaces;
using QueryPressure.Core.Interfaces;
var builder = WebApplication.CreateBuilder(args);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory())
  .ConfigureContainer<ContainerBuilder>(diBuilder => new ApiApplicationLoader().Load(diBuilder));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}
app.MapGet("/providers",
  (IProviderInfo[] providers) =>
    providers.Select(x => x.Name));
app.MapPost("/connection/test",
  async (ConnectionRequest request, ProviderManager manager) =>
    await manager.GetProvider(request.Provider).TestConnectionAsync(request.ConnectionString));

app.MapGet("/profiles", (IProfileCreator[] creators) => creators.Select(x => new{
  x.Arguments,x.Type
}));

app.MapPost("/execution",(ExecutionRequest request, ProviderManager manager)=>
  manager.GetProvider(request.Provider).StartExecutionAsync(request));

app.Run();

public record ExecutionRequest(string ConnectionString, string Provider, string Script, 
  ArgumentsSection Profile, ArgumentsSection Limit);

public record ConnectionRequest(string ConnectionString, string Provider);
