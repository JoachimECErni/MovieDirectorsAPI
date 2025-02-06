using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieDirectorsAPI.Data.Entity;

namespace MovieDirectorsAPI.Data.Configurations
{
    public class CastConfiguration : IEntityTypeConfiguration<Cast>
    {
        public void Configure(EntityTypeBuilder<Cast> builder)
        {
            builder.HasKey(c => c.Id);

            builder.HasOne(c => c.Actor)
                .WithMany(a => a.Movies)
                .HasForeignKey(c => c.ActorId);

            builder.HasOne(c => c.Movie)
                .WithMany(m => m.Cast) 
                .HasForeignKey(c => c.MovieId);
        }
    }
}
