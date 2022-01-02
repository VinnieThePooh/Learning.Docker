using Docker.Volumes.MariaDbReuse.WebApi.DataAccess.Configurations;
using Docker.Volumes.MariaDbReuse.WebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace Docker.Volumes.MariaDbReuse.WebApi.DataAccess;

public class SamplesContext: DbContext
{

    public SamplesContext(DbContextOptions<SamplesContext> options):base(options)
    {
        Samples = Set<DemoSample>();        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(SamplesContext).Assembly);
    }


    public DbSet<DemoSample> Samples { get; set; }   
}
