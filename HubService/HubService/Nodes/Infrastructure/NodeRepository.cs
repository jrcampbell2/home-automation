using HubService.Nodes.Domain;
using HubService.Nodes.Domain.Models;

namespace HubService.Nodes.Infrastructure
{
    // Repository pattern: https://docs.microsoft.com/en-us/ef/core/testing/choosing-a-testing-strategy#repository-pattern
    public class NodeRepository : INodeRepository
    {
        private readonly NodesContext _context;

        public NodeRepository(NodesContext context)
        {
            _context = context;
        }

        public void AddNode(Node node)
        {
            _context.Add(node);
        }

        public IEnumerable<Node> GetAllNodes()
        {
            return _context.Nodes.ToList();
        }

        public Node? GetNodeById(int id)
        {
            return _context.Nodes.FirstOrDefault(x => x.Id == id);
        }

        public Node? GetNodeByName(string name)
        {
            return _context.Nodes.FirstOrDefault(x => x.Name == name);
        }
    }
}
