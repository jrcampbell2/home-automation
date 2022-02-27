using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace HubService.Tests.Nodes.Controllers.v1
{
    [TestClass]
    [TestCategory("Integration")]
    public class NodesControllerTests : IntegrationTestsBase
    {
        public NodesControllerTests() : base()
        {
        }

        [TestMethod]
        public async Task Get_ShouldReturnOkAsync()
        {
            var client = application.CreateClient();
            var response = await client.GetAsync("/Nodes");
            response.EnsureSuccessStatusCode();
        }
    }
}
