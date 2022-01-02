using Docker.Volumes.MariaDbReuse.WebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace Docker.Volumes.MariaDbReuse.WebApi.DataAccess;

public class SamplesContext: DbContext
{
    public SamplesContext()
    {
        Samples = Set<DemoSample>();
    }

    public DbSet<DemoSample> Samples { get; set; }
}
