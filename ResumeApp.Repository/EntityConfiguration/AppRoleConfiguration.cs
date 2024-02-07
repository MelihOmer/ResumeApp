using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ResumeApp.Core.Entities.Identity;

namespace ResumeApp.Repository.EntityConfiguration
{
    public class AppRoleConfiguration : IEntityTypeConfiguration<AppRole>
    {
        public void Configure(EntityTypeBuilder<AppRole> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasData(new AppRole
            {
                Id = "967EAD1D-4F14-4AD6-AB21-05C355E05C72",
                Name = "Admin",
                NormalizedName = "ADMIN",
                ConcurrencyStamp = Guid.NewGuid().ToString()
            }); 
        }
    }
}
