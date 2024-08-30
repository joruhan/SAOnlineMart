using Microsoft.EntityFrameworkCore;
using SAOnlineMart.Areas.Admin.Model; // Import the UserAccount model namespace

namespace SAOnlineMart.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // Update DbSet to use UserAccount
        public DbSet<UserAccount> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuring the table name for the UserAccount entity
            modelBuilder.Entity<UserAccount>()
                .ToTable("Users");

            // Configure the primary key
            modelBuilder.Entity<UserAccount>()
                .HasKey(u => u.UserId);

            // Configure other properties
            modelBuilder.Entity<UserAccount>()
                .Property(u => u.userName)
                .IsRequired()
                .HasMaxLength(256);

            modelBuilder.Entity<UserAccount>()
                .Property(u => u.userEmail)
                .IsRequired()
                .HasMaxLength(256);

            modelBuilder.Entity<UserAccount>()
                .Property(u => u.phoneNumber)
                .HasMaxLength(15);

            modelBuilder.Entity<UserAccount>()
                .Property(u => u.userPassword)
                .IsRequired()
                .HasMaxLength(256);

            modelBuilder.Entity<UserAccount>()
                .Property(u => u.Role)
                .HasMaxLength(50);

            // Seed data or other configurations can be added here
        }
    }
}
