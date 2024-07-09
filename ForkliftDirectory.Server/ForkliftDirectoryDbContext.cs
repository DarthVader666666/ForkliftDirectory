using ForkliftDirectory.Server.Entities;
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
            modelBuilder.Entity<Forklift>(builder => {
                builder.HasKey(x => x.ForkliftId);
            });

            modelBuilder.Entity<Malfunction>(builder => {
                builder.HasKey(x => x.MalfunctionId);

                builder.HasOne<Forklift>(x => x.Forklift)
                    .WithMany(f => f.Malfunctions)
                    .HasForeignKey(x => x.ForkliftId);
            });

        }

        public DbSet<Forklift> Forklifts { get; set; }
        public DbSet<Malfunction> Malfunctions { get; set; }
    }
}
