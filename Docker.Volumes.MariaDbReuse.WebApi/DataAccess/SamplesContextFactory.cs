using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Docker.Volumes.MariaDbReuse.WebApi.DataAccess;

public class SamplesContextFactory : IDesignTimeDbContextFactory<SamplesContext>
{
     public SamplesContext CreateDbContext(string[] args)
    {
        var builder = new DbContextOptionsBuilder<SamplesContext>();
        var serverVersion = new MySqlServerVersion(new Version(8, 0, 27));
        builder.UseMySql(GetConnectionString(), serverVersion, options => options.MigrationsAssembly(typeof(SamplesContext).Assembly.GetName().Name));
        return new SamplesContext(builder.Options);
    }


    private static string GetConnectionString()
    {
        var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
        return config.GetConnectionString("DefaultConnection");                
    }
}
