using HubService.Nodes.Domain;
using HubService.Nodes.Domain.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;
using Shouldly;
using System;

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

        [TestMethod]
        public void AddNode_NullValue_ShouldException()
        {
            var nodeRepoMock = setupNodeRepoMock(new List<Node>());

            var nodeManager = new NodeManager(nodeRepoMock);
            var ex = Assert.ThrowsException<ArgumentNullException>(() => nodeManager.AddNode(null));
            ex.Message.ShouldContain($"Null value was passed to {nameof(NodeManager.AddNode)}");
        }

        [TestMethod]
        public void AddNode_NoNodeName_ShouldException()
        {
            var nodeRepoMock = setupNodeRepoMock(new List<Node>());
            var node = new Node { Description = "test" };

            var nodeManager = new NodeManager(nodeRepoMock);
            var ex = Assert.ThrowsException<ArgumentException>(() => nodeManager.AddNode(node));

            ex.Message.ShouldContain($"Invalid input to '{nameof(NodeManager.AddNode)}', the node name was not specified.");
        }

        [TestMethod]
        public void AddNode_NodeWithName_ShouldAddNodeToRepo()
        {
            var nodeRepoMock = new NodeRepositoryMock();
            var node = new Node { Name = "nodeName1", Description = "test" };

            var nodeManager = new NodeManager(nodeRepoMock);

            nodeRepoMock.AllNodes.Count.ShouldBe(0);
            nodeManager.AddNode(node);
            nodeRepoMock.AllNodes.Count.ShouldBe(2);
        }


        private static INodeRepository setupNodeRepoMock(IEnumerable<Node> getAllNodesResponse)
        {
            var nodeRepoMock = new Mock<INodeRepository>();
            nodeRepoMock.Setup(x => x.GetAllNodes()).Returns(getAllNodesResponse);
            return nodeRepoMock.Object;
        }

        private class NodeRepositoryMock : INodeRepository
        {
            public List<Node> AllNodes = new List<Node>();
            public void AddNode(Node node)
            {
                AllNodes.Add(node);
            }

            public IEnumerable<Node> GetAllNodes()
            {
                return AllNodes;
            }

            public Node? GetNodeById(int id)
            {
                throw new NotImplementedException();
            }

            public Node? GetNodeByName(string name)
            {
                throw new NotImplementedException();
            }
        }
    }
}
