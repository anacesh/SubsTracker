using Microsoft.EntityFrameworkCore;
using SubsTracker.Subs;
using SubsTracker.Users;

namespace SubsTracker.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Sub> Subs { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasKey(u => u.Id);

            modelBuilder.Entity<Sub>()
                .HasKey(s => s.Id);

            modelBuilder.Entity<User>()
                .HasMany(u => u.Subs)
                .WithOne()
                .HasForeignKey("UserId");
        }
    }
}