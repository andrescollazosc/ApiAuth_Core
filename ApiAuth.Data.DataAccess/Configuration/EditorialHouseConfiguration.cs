using ApiAuth.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiAuth.Data.DataAccess.Configuration
{
    public class EditorialHouseConfiguration : IEntityTypeConfiguration<EditorialHouse>
    {
        public void Configure(EntityTypeBuilder<EditorialHouse> entity)
        {
            entity.Property(e => e.HouseName)
                    .HasMaxLength(100)
                    .IsUnicode(false);
        }
    }
}
