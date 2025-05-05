using Microsoft.EntityFrameworkCore;
using TrelloManagementSystem.Models;

namespace TrelloManagementSystem.Common.Database.Context
{
    public class TrelloContext : DbContext
    {
    
        public TrelloContext(DbContextOptions<TrelloContext> options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           optionsBuilder.UseSqlServer("Server=.;Database=TrelloManagmentSystem;Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=True;");
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectTask> Tasks { get; set; }
        public DbSet<User> Users { get; set; }


    }
}
