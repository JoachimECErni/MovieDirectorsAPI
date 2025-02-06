using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieDirectorsAPI.Data.Entity;

namespace MovieDirectorsAPI.Data.Configurations
{
    public class ActorProfileConfiguration : IEntityTypeConfiguration<ActorProfile>
    {
        public void Configure(EntityTypeBuilder<ActorProfile> builder)
        {
            builder.HasKey(ap => ap.Id);

            builder.HasOne(ap => ap.Actor)
                .WithOne(a => a.ActorProfile)
                .HasForeignKey<ActorProfile>(ap => ap.ActorId);
        }
    }
}
