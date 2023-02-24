using LearnPortal.DAL.Entities.CourseType;
using LearnPortal.DAL.Entities.MaterialType;
using LearnPortal.DAL.Entities.UserType;
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

        public static OptionsBuilder OptionsBuilder => new OptionsBuilder();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(
                "Data Source=DESKTOP-1BKP631\\LOCALMSSQLSERVER;Database=db_LearnPortal;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;");
            }
        }
    }
}
