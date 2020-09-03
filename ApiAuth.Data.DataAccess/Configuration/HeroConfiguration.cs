using ApiAuth.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiAuth.Data.DataAccess.Configuration
{
    public class HeroConfiguration : IEntityTypeConfiguration<Hero>
    {
        public void Configure(EntityTypeBuilder<Hero> entity)
        {
            entity.Property(e => e.Id)
                    .HasMaxLength(100)
                    .IsUnicode(false);

            entity.Property(e => e.HeroName)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.Property(e => e.History)
                .HasMaxLength(500)
                .IsUnicode(false);

            entity.Property(e => e.SuperHero)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.Property(e => e.UrlImage)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.Editorial)
                .WithMany(p => p.Hero)
                .HasForeignKey(d => d.EditorialId)
                .HasConstraintName("fk_editorial");
        }
    }
}
