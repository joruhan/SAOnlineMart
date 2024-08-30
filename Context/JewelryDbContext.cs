using Microsoft.EntityFrameworkCore;
using SAOnlineMart.Models;

namespace SAOnlineMart.Context
{
    public class JewelryDbContext : DbContext
    {
        public JewelryDbContext(DbContextOptions<JewelryDbContext> options)
            : base(options)
        {
        }

        public DbSet<JewelryModel> Jewelry { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configurations for JewelryModel entity
            modelBuilder.Entity<JewelryModel>()
                .ToTable("Jewelry")
                .HasKey(j => j.Id);

            modelBuilder.Entity<JewelryModel>()
                .Property(j => j.Name)
                .HasColumnName("productName");

            modelBuilder.Entity<JewelryModel>()
                .Property(j => j.Description)
                .HasColumnName("productDescription");

            modelBuilder.Entity<JewelryModel>()
                .Property(j => j.Price)
                .HasColumnName("productPrice");
        }
    }
}



/*
ADDITIONAL NOTES.
    Be sure to be in the root folder. click ls and cd to 'SAOnlineMar'
    cd .. goes back a folder


TO ADD MIGRATIONS FOLDER (remove --context... if there's more than one folder in Context)
    dotnet ef migrations add MigrationName --context ContextFolderName

TO UPDATE DATABASE (remove --context... if there's more than one folder in Context)
    dotnet ef database update --context ContextFoldername

TO ADD MIGRATION OF DATABASE TABLE (don't need to add table migration if you migrated the folder)(remove --context... if there's more than one folder in Context)
    dotnet ef migrations add TableName --context ContextFolderName

TO CLEAN MIGRATIONS (remove --context... if there's more than one folder in Context)
    rm -rf Migrations --context AplicationDbContext 
    dotnet ef database drop --context ApplicationDbContext

TO REMOVE MIGRATION (remove --context... if there's more than one folder in Context)
    dotnet ef migrations remove --context ContextFolderName

TROUBLESHOOT
    dotnet build to see errors
    dotnet tool install --global dotnet-ef
    dotnet add package Microsoft.EntityFrameworkCore
    dotnet add package Microsoft.EntityFrameworkCore.SqlServer
    dotnet add package Microsoft.EntityFrameworkCore.Design
    dotnet restore

*/
