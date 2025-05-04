using Microsoft.EntityFrameworkCore;

namespace TrelloManagementSystem.Common.Database.Context
{
    public class TrelloContext : DbContext
    {
        public TrelloContext(DbContextOptions<TrelloContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
