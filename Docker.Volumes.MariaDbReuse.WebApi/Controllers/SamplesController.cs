using Docker.Volumes.MariaDbReuse.WebApi.DataAccess;
using Docker.Volumes.MariaDbReuse.WebApi.Extensions;
using Docker.Volumes.MariaDbReuse.WebApi.Models;
using Docker.Volumes.MariaDbReuse.WebApi.Models.Dto.Requests;
using Docker.Volumes.MariaDbReuse.WebApi.Models.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Docker.Volumes.MariaDbReuse.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class SamplesController : ControllerBase
{

    private readonly ILogger<SamplesController> _logger;
    private readonly IConfiguration _config;
    private readonly SamplesContext _context;

    public SamplesController(ILogger<SamplesController> logger, IConfiguration config, SamplesContext context)
    {
        _logger = logger;
        _config = config;
        _context = context;
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

    [HttpPost("insert-sample")]    
    public async Task<IActionResult> InsertSample(CreateSampleRequest request)
    {
        if (request == null)
            return BadRequest("Sample data to insert is null");
        try
        {
            _context.Add(new DemoSample { 
                Name = request.Name,
                Description = request.Description,
            });
            await _context.SaveChangesAsync();
            return Accepted();
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



    [HttpGet("get-samples")]
    public async Task<IActionResult> GetSamples()
    {
        try
        {            
            return Ok(new SamplesResponse
            {
                Samples = await _context.Samples.ToArrayAsync()
            });
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
}
 
