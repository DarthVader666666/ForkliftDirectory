using Microsoft.EntityFrameworkCore;

namespace ForkliftDirectory.Server
{
    public class ForkliftDirectoryDbContext : DbContext
    {
        public ForkliftDirectoryDbContext(DbContextOptions<ForkliftDirectoryDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
