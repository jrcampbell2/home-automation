using HubService.Nodes.Domain.Models;

namespace HubService.Nodes.Domain
{
    public interface INodeRepository
    {
        public Node? GetNodeByName(string name);
        public IEnumerable<Node> GetAllNodes();
        public Node? GetNodeById(int id);
        public void AddNode(Node node);
    }
}
