using Microsoft.AspNetCore.Mvc;

namespace HubService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NodeController : Controller
    {
        private readonly ILogger<NodeController> _logger;

        public NodeController(ILogger<NodeController> logger)
        {
            _logger = logger;
        }

        [HttpGet()]
        public IActionResult Get()
        {
            return View();
        }
    }
}
