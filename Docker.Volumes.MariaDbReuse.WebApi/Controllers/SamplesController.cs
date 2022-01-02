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


    [HttpPost("add-sample")]
    public async Task<IActionResult> AddNewSample()
    {

        return Ok();
    }
}
 
