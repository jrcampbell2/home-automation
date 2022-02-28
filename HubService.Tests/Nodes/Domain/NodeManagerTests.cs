using HubService.Nodes.Domain;
using HubService.Nodes.Domain.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HubService.Tests.Nodes.Domain
{
    [TestClass]
    public class NodeManagerTests
    {
        [TestMethod]
        public void GetNodes_ShouldReturnListOfNodes()
        {
            var nodeRepoMock = new Mock<INodeRepository>();

            var nodeManager = new NodeManager(nodeRepoMock.Object);
            var nodes = nodeManager.GetNodes();
            Assert.IsNotNull(nodes);
            Assert.IsInstanceOfType(nodes,typeof(List<Node>));
        }
    }
}
