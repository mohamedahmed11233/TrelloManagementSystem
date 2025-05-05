using Microsoft.EntityFrameworkCore;
using TrelloManagementSystem.Models;

namespace TrelloManagementSystem.Common.Database.Context
{
    public class TrelloContext : DbContext
    {
        public TrelloContext(DbContextOptions<TrelloContext> options) : base(options)
        {
        }

        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectTask> Tasks { get; set; }

    }
}
