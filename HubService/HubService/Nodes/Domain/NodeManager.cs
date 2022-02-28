using HubService.Nodes.Domain.Models;

namespace HubService.Nodes.Domain
{
    public class NodeManager
    {
        private INodeRepository _nodeRepository;

        public NodeManager(INodeRepository nodeRepository)
        {
            _nodeRepository = nodeRepository;
        }

        public IEnumerable<Node> GetNodes()
        {
            return _nodeRepository.GetAllNodes();
        }

        public void AddNode(Node node)
        {
            _nodeRepository.AddNode(node);
        }
    }
}
