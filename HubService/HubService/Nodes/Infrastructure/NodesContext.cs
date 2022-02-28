using HubService.Nodes.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace HubService.Nodes.Infrastructure
{
    public class NodesContext : DbContext
    {
        public DbSet<Node> Nodes { get; set; }
     
        // In memory database used only for initial application setup testing purposes.
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseInMemoryDatabase("InMemoryDatabase");
    }
}
