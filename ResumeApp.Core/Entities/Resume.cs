using ResumeApp.Core.Common;

namespace ResumeApp.Core.Entities
{
    public class Resume : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string WebSiteUrl { get; set; }
        public string LinkedinUrl { get; set; }
        public string TwitterUrl { get; set; }
        public string FacebookUrl { get; set; }
        public string GithubUrl { get; set; }
        public string YoutubeChannelUrl { get; set; }
        public ICollection<Experience> Experiences { get; set; }
        public ICollection<Education> Educations{ get; set; }
        public ICollection<Skill> Skills{ get; set; }
        public ICollection<ProgramingLanguage> ProgramingLanguages{ get; set; }
        public ICollection<Project> Projects{ get; set; }
    }
}
