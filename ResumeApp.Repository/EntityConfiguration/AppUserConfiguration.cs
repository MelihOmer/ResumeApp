using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ResumeApp.Core.Entities.Identity;

namespace ResumeApp.Repository.EntityConfiguration
{
    public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.HasKey(x => x.Id);
            var adminUser = new AppUser
            {
                Id = "10037089-DB95-4D47-AEC3-F12A290CC9AB",
                FullName = "Melih Ömer KAMAR",
                UserName = "Admin",
                NormalizedUserName = "ADMIN",
                Email = "admin@mail.com",
                NormalizedEmail = "ADMIN@MAIL.COM",
                PhoneNumber = "123456789",
                PhoneNumberConfirmed = false,
                EmailConfirmed = false,
                SecurityStamp = Guid.NewGuid().ToString(),
            };
            adminUser.PasswordHash = CreatePasswordHash(adminUser,"123456");
            builder.HasData(adminUser);
        }
        private string CreatePasswordHash(AppUser user,string password)
        {
            PasswordHasher<AppUser> passwordHasher = new PasswordHasher<AppUser>();
            return passwordHasher.HashPassword(user, password);
        }
    }
}
