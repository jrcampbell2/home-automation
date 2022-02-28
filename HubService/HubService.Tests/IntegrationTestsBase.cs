using Microsoft.AspNetCore.Mvc.Testing;

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
