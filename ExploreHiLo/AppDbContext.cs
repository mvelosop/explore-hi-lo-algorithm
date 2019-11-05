using Microsoft.EntityFrameworkCore;

namespace ExploreHiLo
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        private DbSet<EntityModel> Entities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasSequence("SqlServerSequence", builder => builder.StartsAt(15).IncrementsBy(10));

            modelBuilder.Entity<EntityModel>()
                .HasKey(e => e.Id);

            modelBuilder.Entity<EntityModel>().Property(e => e.Id)
                .UseHiLo("SqlServerSequence");
        }
    }
}