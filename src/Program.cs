using System.Reflection;
using DistanceArticle.Configuration;
using DistanceArticle.Data;

var builder = WebApplication.CreateBuilder(args);
var environment = builder.Environment.EnvironmentName;

builder
    .Configuration.AddJsonFile($"appsettings.{environment}.json", optional: true, reloadOnChange: true)
    .AddUserSecrets<Program>()
    .AddEnvironmentVariables()
    .Build();

builder.Services.SetupConfigFiles();

// setup database
builder.Services.SetupDatabase<ApplicationDbContext>();
builder.Services.SetupControllers();
builder.Services.AddSwagger();
builder.Services.SetupFilters();

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

// setup identity
// setup authentication
builder.Services.RegisterServices();
builder.Services.SetupJsonOptions();

var app = builder.Build();
app.RegisterSwagger();
app.RegisterMiddleware();

// seed db here if needed
app.Run();

// this is here for integration tests
public partial class Program;
