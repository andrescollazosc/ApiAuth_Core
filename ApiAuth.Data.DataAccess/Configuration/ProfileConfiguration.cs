using ApiAuth.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiAuth.Data.DataAccess.Configuration
{
    public class ProfileConfiguration : IEntityTypeConfiguration<ProfileEnt>
    {
        public void Configure(EntityTypeBuilder<ProfileEnt> entity)
        {
            entity.Property(e => e.Description)
                    .HasMaxLength(60)
                    .IsUnicode(false);
        }
    }
}
