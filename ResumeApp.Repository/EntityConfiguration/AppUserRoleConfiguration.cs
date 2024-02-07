using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ResumeApp.Core.Entities.Identity;

namespace ResumeApp.Repository.EntityConfiguration
{
    public class AppUserRoleConfiguration : IEntityTypeConfiguration<AppUserRole>
    {
        public void Configure(EntityTypeBuilder<AppUserRole> builder)
        {
            builder.HasData(new AppUserRole
            {
                RoleId = "967EAD1D-4F14-4AD6-AB21-05C355E05C72",
                UserId = "10037089-DB95-4D47-AEC3-F12A290CC9AB"
            });
        }
    }
}
