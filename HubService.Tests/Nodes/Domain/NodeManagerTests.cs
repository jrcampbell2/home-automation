using HubService.Nodes.Domain;
using HubService.Nodes.Domain.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
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
            var nodeManager = new NodeManager();
            var nodes = nodeManager.GetNodes();
            Assert.IsNotNull(nodes);
            Assert.IsInstanceOfType(nodes,typeof(List<Node>));
        }
    }
}
