using HubService.Nodes.Domain;
using HubService.Nodes.Domain.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;
using Shouldly;

namespace HubService.Tests.Nodes.Domain
{
    [TestClass]
    public class NodeManagerTests
    {
        [TestMethod]
        public void GetNodes_NoNodes_ShouldReturnEmptyList()
        {
            var nodeRepoMock = setupNodeRepoMock(new List<Node>());

            var nodeManager = new NodeManager(nodeRepoMock);
            var nodes = nodeManager.GetNodes();
            nodes.ShouldNotBeNull();
            nodes.ShouldBeEmpty();
            nodes.ShouldBeOfType<List<Node>>();
        }

        [TestMethod]
        public void GetNodes_TwoNodes_ShouldReturnAllNodes()
        {
            var allNodes = new List<Node>
            {
                new Node{ Id = 1, Name = "test1" },
                new Node{ Id = 2, Name = "test2"}
            };
            var nodeRepoMock = setupNodeRepoMock(allNodes);

            var nodeManager = new NodeManager(nodeRepoMock);
            var nodes = nodeManager.GetNodes();
            nodes.ShouldNotBeNull();
            nodes.Count().ShouldBe(2);
        }

        private static INodeRepository setupNodeRepoMock(IEnumerable<Node> getAllNodesResponse)
        {
            var nodeRepoMock = new Mock<INodeRepository>();
            nodeRepoMock.Setup(x => x.GetAllNodes()).Returns(getAllNodesResponse);
            return nodeRepoMock.Object;
        }
    }
}
