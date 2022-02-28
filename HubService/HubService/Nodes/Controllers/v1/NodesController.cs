using HubService.Nodes.Domain;
using HubService.Nodes.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace HubService.Nodes.Controllers.v1
{
    [ApiController]
    [Route("[controller]")]
    public class NodesController : Controller
    {
        private readonly ILogger<NodesController> _logger;
        private readonly NodeManager _nodeManager;

        public NodesController(ILogger<NodesController> logger, NodeManager nodeManager)
        {
            _logger = logger;
            _nodeManager = nodeManager;
        }

        [HttpGet()]
        public IActionResult Get()
        {
            return  Ok(_nodeManager.GetNodes());
        }

        [HttpPost]
        public IActionResult AddNode(Node node)
        {

            return Ok();
        }
    }
}
