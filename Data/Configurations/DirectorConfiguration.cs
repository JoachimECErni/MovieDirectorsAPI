using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieDirectorsAPI.Data.Entity;

namespace MovieDirectorsAPI.Data.Configurations
{
    public class DirectorConfiguration : IEntityTypeConfiguration<Director>
    {
        public void Configure(EntityTypeBuilder<Director> builder)
        {
            builder.HasMany(d => d.Movies)
               .WithOne(m => m.Director);
        }
    }
}
