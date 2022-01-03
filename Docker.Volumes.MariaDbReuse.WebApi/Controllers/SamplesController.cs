using Docker.Volumes.MariaDbReuse.WebApi.Models.Dtos;
using Microsoft.AspNetCore.Mvc;
namespace Docker.Volumes.MariaDbReuse.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class SamplesController : ControllerBase
{

    private readonly ILogger<SamplesController> _logger;

    public SamplesController(ILogger<SamplesController> logger)
    {
        _logger = logger;
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
        var conString = Environment.GetEnvironmentVariable("MARIADB_DB_ConnectionString");        

        return Ok(new EnvironmentDto { 
            ConnectionString = conString,
        });
    }



    [HttpPost("add-sample")]
    public async Task<IActionResult> AddNewSample()
    {

        return Ok();
    }
}
 
