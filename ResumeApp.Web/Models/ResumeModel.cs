using ResumeApp.Core.Entities;

namespace ResumeApp.Web.Models
{
    public class ResumeModel
    {
        public IEnumerable<Experience> Experiences{ get; set; }
        public IEnumerable<Education> Educations { get; set; }
        public IEnumerable<Skill> Skills { get; set; }
        public IEnumerable<ProgramingLanguage> ProgramingLanguages { get; set; }
    }
}
