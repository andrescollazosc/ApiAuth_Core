using ApiAuth.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiAuth.Data.DataAccess.Configuration
{
    public class MenuConfiguration : IEntityTypeConfiguration<Menu>
    {
        public void Configure(EntityTypeBuilder<Menu> entity)
        {
            entity.Property(e => e.MenuName)
                .HasMaxLength(60)
                .IsUnicode(false);

            entity.Property(e => e.MenuUrl)
                .HasMaxLength(60)
                .IsUnicode(false);
        }
    }
}
