using DataAccess;
using DigitalDocumentAPI.Extensions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Shared.SettingsModels;
using System.Text;

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

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
  options.RequireHttpsMetadata = false;
  options.SaveToken = true;
  options.TokenValidationParameters = new TokenValidationParameters()
  {
    ValidateIssuer = true,
    ValidateAudience = true,
    ValidAudience = builder.Configuration["Jwt:Audience"],
    ValidIssuer = builder.Configuration["Jwt:Issuer"],
    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
  };
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
