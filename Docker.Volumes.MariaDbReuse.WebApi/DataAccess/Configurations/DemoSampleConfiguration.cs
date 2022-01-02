using Docker.Volumes.MariaDbReuse.WebApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Docker.Volumes.MariaDbReuse.WebApi.DataAccess.Configurations;

public class DemoSampleConfiguration : IEntityTypeConfiguration<DemoSample>
{
    public void Configure(EntityTypeBuilder<DemoSample> builder)
    {
        builder.HasKey(x => x.SampleId);
    }
}
