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
            validateInputParamterToAddNode(node);

            _nodeRepository.AddNode(node);
        }

        private static void validateInputParamterToAddNode(Node node)
        {
            if (node == null) throw new ArgumentNullException($"Null value was passed to {nameof(NodeManager.AddNode)}");
            if (string.IsNullOrEmpty(node.Name)) throw new ArgumentException($"Invalid input to '{nameof(NodeManager.AddNode)}', the node name was not specified.");
        }
    }
}
