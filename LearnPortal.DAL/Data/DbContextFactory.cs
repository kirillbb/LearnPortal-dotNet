using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace LearnPortal.DAL.Data
{
    public class DbContextFactory : IDesignTimeDbContextFactory<ApplicationContext>
    {
        public ApplicationContext CreateDbContext(string[] args)
        {
            ApplicationConfiguration configuration = new ApplicationConfiguration();
            var dbContextOptionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
            dbContextOptionsBuilder.UseSqlServer(configuration.SqlConnectionString);
            return new ApplicationContext(dbContextOptionsBuilder.Options);
        }
    }
}
