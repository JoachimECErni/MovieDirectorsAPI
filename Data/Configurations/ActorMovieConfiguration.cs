using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieDirectorsAPI.Data.Entity;

namespace MovieDirectorsAPI.Data.Configurations
{
    public class ActorMovieConfiguration : IEntityTypeConfiguration<ActorMovie>
    {
        public void Configure(EntityTypeBuilder<ActorMovie> builder)
        {
            builder.HasKey(am => am.Id);

            builder.HasOne(am => am.Actor)
                .WithMany(a => a.ActorMovies)
                .HasForeignKey(am => am.ActorId);

            builder.HasOne(am => am.Movie)
                .WithMany(m => m.ActorMovies) 
                .HasForeignKey(am => am.MovieId);
        }
    }
}
