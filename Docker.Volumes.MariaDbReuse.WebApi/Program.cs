using Docker.Volumes.MariaDbReuse.WebApi.DataAccess;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

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
builder.Services.AddEntityFrameworkMySql();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.MapControllers();

using var context = app.Services.GetService<SamplesContext>();
if (context is not null) 
    context.Database.Migrate();

app.Run();
