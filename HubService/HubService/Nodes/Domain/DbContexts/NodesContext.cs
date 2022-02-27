using HubService.Nodes.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace HubService.Nodes.Domain.DbContexts
{
    public class NodesContext : DbContext
    {
        public DbSet<Node> Nodes { get; set; }

        public string DbPath { get; }

        public NodesContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Join(path, "nodes.db"); // To-do, hard coded path should be moved to configuration.
        }

        // The following configures EF to create a Sqlite database file in the
        // special "local" folder for your platform.
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={DbPath}");
    }
}
