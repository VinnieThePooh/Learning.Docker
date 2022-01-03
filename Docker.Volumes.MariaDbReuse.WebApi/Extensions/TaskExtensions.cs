namespace Docker.Volumes.MariaDbReuse.WebApi.Extensions;

public static class TaskExtensions
{
    public static async Task WithTimeout(this Task task, TimeSpan timeout)
    {
        var delay = Task.Delay(timeout);
        var result = await Task.WhenAny(task, delay);
        if (result == delay)
            throw new TimeoutException($"Thrown by operation timeout: {timeout}");        
    }
}
