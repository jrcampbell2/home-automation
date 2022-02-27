using HubService.Nodes.Domain.Models;

namespace HubService.Nodes.Domain
{
    public class NodeManager
    {
        public IEnumerable<Node> GetNodes()
        {
            return new List<Node>();
        }
    }
}
