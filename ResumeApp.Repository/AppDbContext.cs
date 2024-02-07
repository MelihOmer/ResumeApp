using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ResumeApp.Core.Entities;
using ResumeApp.Core.Entities.Identity;
using ResumeApp.Repository.EntityConfiguration;

namespace ResumeApp.Repository
{
    public class AppDbContext : IdentityDbContext<AppUser,AppRole,string,IdentityUserClaim<string>,AppUserRole,IdentityUserLogin<string>,IdentityRoleClaim<string>,IdentityUserToken<string>>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Resume> Resumes{ get; set; }
        public DbSet<Experience> Experiences{ get; set; }
        public DbSet<Education> Educations{ get; set; }
        public DbSet<Skill> Skills{ get; set; }
        public DbSet<ProgramingLanguage> ProgramingLanguages{ get; set; }
        public DbSet<Project> Projects{ get; set; }
        public DbSet<Contact> Contact { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppUserConfiguration).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
