using LearnPortal.DAL.Entities.Course;
using LearnPortal.DAL.Entities.Material;
using LearnPortal.DAL.Entities.User;
using Microsoft.EntityFrameworkCore;

namespace LearnPortal.DAL.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext()
        {
        }

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; } = null!;

        public DbSet<Material> Materials { get; set; } = null!;

        public DbSet<Book> Books { get; set; } = null!;

        public DbSet<Video> Videos { get; set; } = null!;

        public DbSet<Publication> Publications { get; set; } = null!;

        public DbSet<Course> Courses { get; set; } = null!;

        public DbSet<Skill> Skills { get; set; } = null!;
    }
}
