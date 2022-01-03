namespace Docker.Volumes.MariaDbReuse.WebApi.Models.Dtos;

public class ConnectionStatusResponse
{
    private ConnectionStatusResponse(bool succeeded)
    {
        IsSucceeded = succeeded;
    }

    public bool IsSucceeded { get; init; }

    public static ConnectionStatusResponse Succeded => new ConnectionStatusResponse(true);
    public static ConnectionStatusResponse Failed => new ConnectionStatusResponse(false);
}
