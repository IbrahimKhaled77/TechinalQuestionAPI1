using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using Serilog;
using System.Configuration;
using System.Reflection;
using System.Text.Json.Serialization;
using TechnicalQuestionAPI.Context;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers().AddJsonOptions(x =>
{
    x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Skills Magnet API",
        Version = "v1",
        Description = "An API to perform Technical Exams operations For Job Sekker",
        TermsOfService = new Uri("https://example.com/terms"),
        Contact = new OpenApiContact
        {
            Name = "Jasser Alshaer",
            Email = "joshaer17@gmail.com",
            Url = new Uri("https://twitter.com/jwalkner"),
        }
    });
    //enable comments
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});
builder.Services.AddDbContext<TechnicalQuestionDbContext>(cnn => cnn.UseSqlServer(builder.Configuration.GetConnectionString("sqlconnect")));
//builder.Services.AddDbContext<TechnicalQuestionDbContext>(option => option.UseMySQL(builder.Configuration.GetConnectionString("mysqlconnect")));
var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
Serilog.Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(configuration).
                WriteTo.File(configuration.GetValue<string>("LoggerFilePath")
                , rollingInterval: RollingInterval.Day).MinimumLevel.Debug().
                CreateLogger();
Serilog.Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(configuration).
                WriteTo.File(configuration.GetValue<string>("LoggerErrorFilePath")
                , rollingInterval: RollingInterval.Day).MinimumLevel.Error().
                CreateLogger();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
try
{
    Log.Information("Starting web host");
    //CreateHostBuilder(args).Build().Run();
    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Host terminated unexpectedly");
}
finally
{
    Log.CloseAndFlush();
}

