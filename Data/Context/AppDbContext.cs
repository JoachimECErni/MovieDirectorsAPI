

using Microsoft.EntityFrameworkCore;
using MovieDirectorsAPI.Data.Configurations;
using MovieDirectorsAPI.Data.Entity;

namespace MovieDirectorsAPI.Data.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Director> Directors { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Cast> Cast { get; set; }
        public DbSet<ActorProfile> ActorProfiles { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Director
            modelBuilder.ApplyConfiguration(new DirectorConfiguration());

            // Cast
            modelBuilder.ApplyConfiguration(new CastConfiguration());

            // Actor Profile
            modelBuilder.ApplyConfiguration(new ActorProfileConfiguration());
        }
    }
}
