using Docker.Volumes.MariaDbReuse.WebApi.DataAccess;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var isProd = builder.Environment.IsEnvironment(Environments.Production);
var envName = builder.Environment.EnvironmentName;

builder.Configuration    
    .AddJsonFile($"appsettings{(isProd ? string.Empty: "." + envName)}.json", false)
    .AddEnvironmentVariables();

var conString = builder.Configuration.GetConnectionString("DefaultConnection");
Console.WriteLine($"Environment: {(!string.IsNullOrEmpty(envName) ? envName: Environments.Production)}");
Console.WriteLine($"Connection string: {(!string.IsNullOrEmpty(conString) ? conString : "NULL")}");

builder.WebHost.ConfigureKestrel(options => {
    options.ListenAnyIP(8081);     
});

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddDbContext<SamplesContext>(options =>
{
    var serverVersion = new MySqlServerVersion(new Version(8, 0, 27));
    options.UseMySql(conString, serverVersion, options => options.MigrationsAssembly(typeof(SamplesContext).Assembly.GetName().Name));
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();
app.MapControllers();

using var scope = app.Services.CreateScope();
var context = scope.ServiceProvider.GetRequiredService<SamplesContext>();
context.Database.Migrate();
app.Run();
