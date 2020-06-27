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

        public virtual DbSet<Profile> Profile { get; set; }
        public virtual DbSet<UserType> UserType { get; set; }
        public virtual DbSet<Users> Users { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                optionsBuilder.UseSqlServer("Data Source=DESKTOP-UNL1N5F\\SQLEXPRESS;Initial Catalog=db_test_user;Integrated Security=True;");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProfileConfiguration());
            modelBuilder.ApplyConfiguration(new UserTypeConfiguration());
            modelBuilder.ApplyConfiguration(new UsersConfiguration());

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
