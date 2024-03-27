using Microsoft.AspNetCore.Mvc;

namespace api.Controllers.Public;

[Route("[controller]")]
[ApiController]
public class HealthController : ControllerBase
{
    [HttpGet]
    public IActionResult Health()
    {
        return Ok("I'm alive 💓");
    }
}