using ApiAuth.Data.DataAccess.Configuration;
using ApiAuth.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ApiAuth.Data.DataAccess
{
    public partial class db_test_userContext : DbContext
    {
        public db_test_userContext()
        {
        }

        public db_test_userContext(DbContextOptions<db_test_userContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ProfileEnt> Profile { get; set; }
        public virtual DbSet<UserType> UserType { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<EditorialHouse> EditorialHouse { get; set; }
        public virtual DbSet<Hero> Hero { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProfileConfiguration());
            modelBuilder.ApplyConfiguration(new UserTypeConfiguration());
            modelBuilder.ApplyConfiguration(new UsersConfiguration());
            modelBuilder.ApplyConfiguration(new HeroConfiguration());
            modelBuilder.ApplyConfiguration(new EditorialHouseConfiguration());

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
