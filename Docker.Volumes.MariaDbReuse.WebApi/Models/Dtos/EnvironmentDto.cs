using System.Text.Json.Serialization;

namespace Docker.Volumes.MariaDbReuse.WebApi.Models.Dtos;

public class EnvironmentDto
{
    [JsonPropertyName("MARIADB_DB_ConnectionString")]
    public string? ConnectionString { get; set; }
}
