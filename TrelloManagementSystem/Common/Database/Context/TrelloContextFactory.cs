using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;

namespace TrelloManagementSystem.Common.Database.Context
{
    public class TrelloContextFactory : IDesignTimeDbContextFactory<TrelloContext>
    {
        public TrelloContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<TrelloContext>();
            optionsBuilder.UseSqlServer("DefaultConnection");

            return new TrelloContext(optionsBuilder.Options);
        }
    }

}
