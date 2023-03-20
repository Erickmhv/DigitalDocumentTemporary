using DataAccess.Configuration;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class SqlServerContext : DbContext
    {
        public DbSet<UserDbModel> Users { get ; set ; }
        public DbSet<RoleDbModel> Roles { get; set; }
        public DbSet<PasswordChangeDbModel> PasswordChanges { get ; set ; }
        public DbSet<AcademicInstitutionDbModel> Brands { get ; set ; }
        public DbSet<DocumentTypeDbModel> DocumentTypes { get ; set ; }
        public DbSet<CareersDbModel> Careers { get ; set ; }
        public DbSet<LegalizationRequestDbModel> LegalizationRequests { get ; set ; }

        public SqlServerContext(DbContextOptions<SqlServerContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AcademicInstitutionConfiguration());
            modelBuilder.ApplyConfiguration(new CareersConfiguration());
            modelBuilder.ApplyConfiguration(new DocumentTypeConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
        }
    }
}
