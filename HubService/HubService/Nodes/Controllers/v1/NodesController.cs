using Microsoft.AspNetCore.Mvc;

namespace HubService.Nodes.Controllers.v1
{
    [ApiController]
    [Route("[controller]")]
    public class NodesController : Controller
    {
        private readonly ILogger<NodesController> _logger;

        public NodesController(ILogger<NodesController> logger)
        {
            _logger = logger;
        }

        [HttpGet()]
        public IActionResult Get()
        {
            return Ok();
        }
    }
}
