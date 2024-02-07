using Microsoft.AspNetCore.Identity;

namespace ResumeApp.Core.Entities.Identity
{
    public class AppUser : IdentityUser<string>
    {
        public string FullName { get; set; }
    }
}
