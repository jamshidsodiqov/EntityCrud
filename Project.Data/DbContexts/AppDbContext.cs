using Microsoft.EntityFrameworkCore;
using Project.Domain.Entities.Courses;
using Project.Domain.Entities.Students;
using Project.Domain.Entities.Teachers;

namespace Project.Data.DbContexts
{
    public class AppDbContext : DbContext
    {
        public DbSet<Course> Courses { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost; Port=5432; Username=postgres; Password=1234; Database=ProjectDb");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
                .HasIndex(u => u.Password)
                .IsUnique(true);
        }
    }
}
