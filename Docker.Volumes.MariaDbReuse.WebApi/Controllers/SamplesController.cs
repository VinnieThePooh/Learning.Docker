using Docker.Volumes.MariaDbReuse.WebApi.Extensions;
using Docker.Volumes.MariaDbReuse.WebApi.Models.Dtos;
using Microsoft.AspNetCore.Mvc;
namespace Docker.Volumes.MariaDbReuse.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class SamplesController : ControllerBase
{

    private readonly ILogger<SamplesController> _logger;
    private readonly IConfiguration _config;

    public SamplesController(ILogger<SamplesController> logger, IConfiguration config)
    {
        _logger = logger;
        _config = config;
    }

    [HttpGet("get-samples")]
    public async Task<IActionResult> GetDemoSamples()
    {
        return Ok();
    }

    [HttpGet("start")]
    public async Task<IActionResult> Start()
    {
        return Ok("WebApi client is ready!");
    }


    [HttpGet("get-environment")]
    public async Task<IActionResult> GetEnvironmentVariables()
    {
        var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

        return Ok(new EnvironmentResponse { 
            Environment = env,
        });
    }

    [HttpGet("check-dbconnection")]
    public async Task<IActionResult> CheckConnection()
    {
        var conString = _config.GetConnectionString("DefaultConnection");

        try
        {            
            using var con = new MySqlConnector.MySqlConnection(conString);
            await con.OpenAsync().WithTimeout(TimeSpan.FromSeconds(3));
            return Ok(ConnectionStatusResponse.Succeded);
        }
        catch (TimeoutException)
        {
           return Ok(ConnectionStatusResponse.Failed);
        }
        catch (Exception e)
        {
            return BadRequest(e.ToString());
        }
    }


    [HttpPost("add-sample")]
    public async Task<IActionResult> AddNewSample()
    {

        return Ok();
    }
}
 
