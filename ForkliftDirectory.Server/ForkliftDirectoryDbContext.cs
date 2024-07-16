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

                builder.Property(f => f.ForkliftId).HasIdentityOptions(startValue: 4);
            });

            modelBuilder.Entity<Malfunction>(builder => {
                builder.HasKey(x => x.MalfunctionId);

                builder.HasOne<Forklift>(x => x.Forklift)
                    .WithMany(f => f.Malfunctions)
                    .HasForeignKey(x => x.ForkliftId);

                builder.Property(f => f.MalfunctionId).HasIdentityOptions(startValue: 10);
            });

            modelBuilder.Entity<User>(builder =>
            {
                builder.HasKey(x => x.UserId);

                builder.Property(f => f.UserId).HasIdentityOptions(startValue: 4);
            });

        }

        public DbSet<Forklift> Forklifts { get; set; }
        public DbSet<Malfunction> Malfunctions { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
