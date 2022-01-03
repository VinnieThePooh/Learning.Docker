using Docker.Volumes.MariaDbReuse.WebApi.DataAccess;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);    
builder.Configuration.AddEnvironmentVariables();
builder.WebHost.ConfigureKestrel(options => {
    options.ListenAnyIP(8081);     
});

var conString = Environment.GetEnvironmentVariable("MARIADB_DB_ConnectionString");
Console.WriteLine($"Connection string: {(!string.IsNullOrEmpty(conString) ? conString: "NULL")}");

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

using var context = app.Services.GetService<SamplesContext>();
//context.Database.Migrate();
app.Run();
