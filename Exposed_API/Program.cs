using DataAccess;
using Exposed_API.Extensions;
using Microsoft.EntityFrameworkCore;
using Shared.SettingsModels;

var builder = WebApplication.CreateBuilder(args);

builder.Services.RegisterAppDependencies();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.RegisterMappingProfiles();

var configurationBuilder = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json");

IConfiguration configuration = configurationBuilder.Build();

builder.Services.Configure<FileServiceSettings>(configuration);
builder.Services.Configure<SMTPServiceSettings>(configuration);

builder.Services.AddDbContext<SqlServerContext>(options =>
{
    options.UseSqlServer(configuration.GetConnectionString("ConnectionString"));
});

var app = builder.Build();

//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}

app.UseCors(b => b
     .AllowAnyOrigin()
     .AllowAnyMethod()
     .AllowAnyHeader());

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.ConfigureExceptionHandler();


app.Run();