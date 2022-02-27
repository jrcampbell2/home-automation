using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HubService.Tests
{
    public abstract class IntegrationTestsBase
    {
        public WebApplicationFactory<Program> application;

        public IntegrationTestsBase()
        {
            application = new WebApplicationFactory<Program>()
            .WithWebHostBuilder(builder =>
            {
                // ... Configure test services
            });
        }
    }
}
