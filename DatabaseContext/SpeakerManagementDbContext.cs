using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SpeakerManagementSystem.Infrastructure;
using SpeakerManagementSystem.Models;
using SpeakerManagementSystem.Models.Common;

namespace SpeakerManagementSystem.DatabaseContext
{
    public class SpeakerMgmtDbContext : IdentityDbContext<ApplicationUser>
    {
        public SpeakerMgmtDbContext(DbContextOptions<SpeakerMgmtDbContext> options) : base(options)
        {
        }

        #region Entities

        // DbSet properties for your entities
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<Tasks> Tasks { get; set; }

        #endregion

        #region Protected
        
        /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            // Register interceptor
            optionsBuilder.AddInterceptors(new AuditInterceptor());
        }*/

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure Id property as primary key
            modelBuilder.Entity<Tasks>().HasKey(t => t.Id);
            modelBuilder.Entity<Organization>().HasKey(t => t.Id);

            base.OnModelCreating(modelBuilder);

            // MSSQL uses the dbo schema by default - not public.
            modelBuilder.HasDefaultSchema("dbo");

            modelBuilder.Entity<ApplicationUser>(entity =>
            {
                entity.ToTable(name: "User");
            });

            modelBuilder.Entity<IdentityRole>(entity =>
            {
                entity.ToTable(name: "Role");
            });

            modelBuilder.Entity<IdentityRoleClaim<string>>(entity =>
            {
                entity.ToTable(name: "RoleClaim");
            });

            modelBuilder.Entity<IdentityUserClaim<string>>(entity =>
            {
                entity.ToTable(name: "UserClaim");
            });

            modelBuilder.Entity<IdentityUserLogin<string>>(entity =>
            {
                entity.ToTable(name: "UserLogin");
            });

            modelBuilder.Entity<IdentityUserRole<string>>(entity =>
            {
                entity.ToTable(name: "UserRole");
            });

            modelBuilder.Entity<IdentityUserToken<string>>(entity =>
            {
                entity.ToTable(name: "UserToken");
            });

        }
        
        #endregion
    }
}
