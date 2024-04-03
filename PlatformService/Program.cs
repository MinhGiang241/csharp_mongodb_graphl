using HotChocolate.AspNetCore;
using HotChocolate.AspNetCore.Playground;
using PlatformService.Models;
using PlatformService.Services;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
builder.Services.AddOptions();

// Add services to the container.
// builder.Services.Configure<DataSetting>(
IConfigurationSection databaSettings = builder.Configuration.GetSection(nameof(DataSetting));
builder.Services.Configure<DataSetting>(databaSettings);
builder.Services.AddSingleton<DatabaseServices>();
builder.Services.AddGraphQLServer().AddQueryType<Query>();
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    _ = app.UseDeveloperExceptionPage();
    _ = app.UsePlayground(new PlaygroundOptions { QueryPath = "/api", Path = "/playground" });
}

app.UseHttpsRedirection();
app.MapGraphQL("/api");

app.UseAuthorization();

app.MapControllers();

app.Run();
